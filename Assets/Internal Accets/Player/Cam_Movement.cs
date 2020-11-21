using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Movement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float y_angle = 60;
    [SerializeField] float distance = 10;
    [SerializeField] float rotation_power = 1f;
    void Start()
    {

    }
    float r_axis;
    void CheckRotate()
    {
        r_axis = Input.GetAxis("Cam_Rotation");
        if (r_axis != 0)
        {
            RotateCam(r_axis);
        }
    }
    public void MoveCam()
    {
        Vector3 forw = transform.forward;
        transform.position = player.transform.position - forw * distance;
    }
    void RotateCam(float r)
    {
        r *= -1 * rotation_power / 10;
        transform.RotateAround(player.transform.position, Vector3.up, r);
    }
    private void Update()
    {
        CheckRotate();
        MoveCam();
    }
}
