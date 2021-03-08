using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cam_Movement : MonoBehaviour
{
    enum CamPersonMode
    {
        FirstPersonMode,
        ThirdPersonMode,
        Ghost
    }
    [SerializeField] CamPersonMode cam_mode;
    [SerializeField] float distance = 10;
    [SerializeField] float sensitivity = 1f;
    [SerializeField] float lift_up_cam = 2;
    Vector3 LiftUp
    {
        get
        {
            return Vector3.up * lift_up_cam;
        }
    }
    void Start()
    {
        
    }
    Vector2 mouse_axis;
    void CheckRotate()
    {
        mouse_axis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (mouse_axis.magnitude != 0)
            RotateCam(mouse_axis);
    }
    RaycastHit hit_info;
    
    public void MoveCam()
    {
        Vector3 forw = transform.forward;
        float real_distance = distance;
        transform.position = Player_Cam_Singleton.player.position + LiftUp;

        if (cam_mode == CamPersonMode.ThirdPersonMode)
        {
            if (Physics.Raycast(new Ray(transform.position, -forw), out hit_info) && Vector3.Distance(transform.position, hit_info.point) < distance)
                transform.position = hit_info.point + forw * 0.1f;
            else 
                transform.position = transform.position - forw * distance + forw * 0.1f;
        }
        else if (cam_mode == CamPersonMode.FirstPersonMode)
        {
            transform.position = Player_Cam_Singleton.player.position;
        }
        else if (cam_mode == CamPersonMode.Ghost)
        {
            transform.position = Player_Cam_Singleton.player.position - forw * real_distance;
        }
    }
    void RotateCam(Vector2 _mouse_axis)
    {
        _mouse_axis *= sensitivity / 10;
        _mouse_axis.y *= -1;

        if (cam_mode == CamPersonMode.ThirdPersonMode)
        {
            transform.RotateAround(Player_Cam_Singleton.player.position + LiftUp, Vector3.up, _mouse_axis.x);
            transform.RotateAround(Player_Cam_Singleton.player.position + LiftUp, transform.right, _mouse_axis.y);
            if (transform.eulerAngles.z > 90)
                transform.RotateAround(Player_Cam_Singleton.player.position + LiftUp, transform.right, -_mouse_axis.y);
        }
        else if (cam_mode == CamPersonMode.FirstPersonMode)
        {
            transform.Rotate(new Vector3(0, _mouse_axis.x, 0), Space.World);
            transform.Rotate(new Vector3(_mouse_axis.y, 0, 0), Space.Self);

        }
        else if (cam_mode == CamPersonMode.Ghost)
        {
            transform.RotateAround(Player_Cam_Singleton.player.position, Vector3.up, _mouse_axis.x);
        }
       
        
    }
    private void Update()
    {
        CheckRotate();
        MoveCam();
    }
}
