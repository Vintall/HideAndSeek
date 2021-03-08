using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Logic : MonoBehaviour
{
    [SerializeField] float jump_speed;
    [SerializeField] float jump_cooldown;
    [SerializeField] float angle;
    Rigidbody rb;
    bool can_jump = false;
    bool is_on_ground;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        JumpLogic();
    }

    bool cooldown_coroutine = true;
    IEnumerator ReJumpCooldown()
    {
        cooldown_coroutine = false;
        yield return new WaitForSeconds(jump_cooldown);
        can_jump = true;
        cooldown_coroutine = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
            if (Vector3.Angle(new Vector3(contact.normal.x, 0, contact.normal.z), contact.normal) > angle
                || Vector3.Angle(new Vector3(contact.normal.x, 0, contact.normal.z), contact.normal) == 0)
            {
                //is_on_ground = true;
                if (cooldown_coroutine)
                    StartCoroutine(ReJumpCooldown());
                    break;
            }
    }
    private void OnCollisionExit(Collision collision)
    {
        is_on_ground = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        float normal_angle;
        foreach (ContactPoint contact in collision.contacts)
        {
            normal_angle = Vector3.Angle(new Vector3(contact.normal.x, 0, contact.normal.z), contact.normal);
            if (normal_angle >= angle || normal_angle == 0)
            {
                is_on_ground = true;
                //if (!can_jump)
                //StartCoroutine(ReJumpCooldown());
                break;
            }
        }
    }
    void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0 && is_on_ground && can_jump)
        {
            rb.AddForce(Vector3.up * jump_speed * rb.mass);
            can_jump = false;
        }
    }
}
