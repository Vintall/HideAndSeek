using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsState : MonoBehaviour
{
    [SerializeField] PropStates prop_state;
    [SerializeField] float mass;
    public const float angle = 45;
    bool is_on_ground;
    enum PropStates
    {
        FreeProp,
        Player
    }
    public bool IsOnGround
    {
        get { return is_on_ground; }
    }
    public float Mass
    {
        get { return mass; }
    }
    private void OnCollisionEnter(Collision collision)
    {
        float normal_angle;
        foreach (ContactPoint contact in collision.contacts)
        {
            normal_angle = Vector3.Angle(new Vector3(contact.normal.x, 0, contact.normal.z), contact.normal);
            if (normal_angle >= angle || normal_angle == 0)
            {
                is_on_ground = true;
            }
            break;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        is_on_ground = false;
    }
}
