using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movenent : MonoBehaviour
{

    [SerializeField] float move_speed = 10f;
    [SerializeField] float jump_speed = 10f;
    [SerializeField] Camera cam;
    Rigidbody rb;
    Vector3 start_angle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start_angle = transform.rotation.eulerAngles;
    }
    bool is_on_ground = false;
    void OnGroundCheck(bool is_on, Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (is_on) StartCoroutine(CanJump());
            else
                is_on_ground = is_on;
        }
    }
    IEnumerator CanJump()
    {
        yield return new WaitForSeconds(0.3f);
        is_on_ground = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnGroundCheck(true, collision);
        Debug.Log("On Ground");
    }
    private void OnCollisionExit(Collision collision)
    {
        OnGroundCheck(false, collision);
        Debug.Log("In air space");
    }
    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveLogic();
        JumpLogic();
    }
    void MoveLogic()
    {
        float vertical_axis = Input.GetAxis("Vertical");
        float horizontal_axis = Input.GetAxis("Horizontal");

        Vector3 cam_forv = cam.transform.forward.normalized;
        Vector3 axis = new Vector3(vertical_axis, 0, horizontal_axis);
        float angle = Vector3.Angle(cam_forv, axis);
        cam_forv.y = 0;
        int horizontal_abs;
        if (horizontal_axis == 0) horizontal_abs = 0;
        else horizontal_abs = (int)(horizontal_axis / Mathf.Abs(horizontal_axis));

        Vector3 movement_vertical = cam_forv * vertical_axis;
        Vector3 movement_horizontal = new Vector3(cam_forv.z * horizontal_abs, 0, -1 * cam_forv.x * horizontal_abs);
        Vector3 movement = movement_horizontal + movement_vertical;

        rb.AddForce(movement.normalized * move_speed, ForceMode.Impulse);
        //rb.MoveRotation(Quaternion.Euler(movement.normalized * move_speed));
    }
    
    void JumpLogic()
    {
        if (is_on_ground)
        {
            if (Input.GetAxis("Jump") > 0)
            {
                rb.AddForce(Vector3.up * jump_speed);
            }
        }
    }
    

}
