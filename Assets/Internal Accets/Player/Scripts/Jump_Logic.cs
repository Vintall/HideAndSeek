using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Logic : MonoBehaviour
{
    [SerializeField] float jump_speed;
    [SerializeField] float jump_cooldown;
    [SerializeField] float angle;
    Rigidbody rb;
    bool is_on_ground = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.AddComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        JumpLogic();
    }
    
    IEnumerator CanJump()
    {
        yield return new WaitForSeconds(1f);
        is_on_ground = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
            if (Vector3.Angle(new Vector3(collision.contacts[i].normal.x,0,collision.contacts[i].normal.z),collision.contacts[i].normal) > angle 
                || Vector3.Angle(new Vector3(collision.contacts[i].normal.x,0,collision.contacts[i].normal.z),collision.contacts[i].normal) == 0)
            {
                is_on_ground = true;
                Debug.Log(collision.contacts[i].normal.y);
            }
    }
    IEnumerator Jump()
    {
        rb.AddForce(Vector3.up * jump_speed * rb.mass);
        is_on_ground = false;
        yield return new WaitForSeconds(1);
    }
    private void OnCollisionExit(Collision collision)
    {
        is_on_ground = false;
    }

    void JumpLogic()
    {
        if (is_on_ground)
        {
            if (Input.GetAxis("Jump") > 0)
            {
                //rb.AddForce(Vector3.up * jump_speed * rb.mass);
                StartCoroutine(Jump());
            }
        }
    }
}
