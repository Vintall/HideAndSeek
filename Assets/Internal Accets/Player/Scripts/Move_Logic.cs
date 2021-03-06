using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Logic : MonoBehaviour
{
    [SerializeField] float move_speed;
    [SerializeField] float run_speed;
    [SerializeField] float sneak_speed;
    [SerializeField] public Camera cam;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MoveLogic();
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

        float speed;
        if (Input.GetAxis("Speed_Up") > 0) speed = run_speed;
        else if (Input.GetAxis("Speed_Down") > 0) speed = sneak_speed;
        else speed = move_speed;

        rb.AddForce(movement.normalized * speed * rb.mass, ForceMode.Impulse);
    }
}
