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
    [SerializeField] GameObject player;
    [SerializeField] float distance = 10;
    [SerializeField] float sensitivity = 1f;
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
    public void MoveCam()
    {
        Vector3 forw = transform.forward;
        if (cam_mode == CamPersonMode.ThirdPersonMode)
        {
            transform.position = player.transform.position - forw * distance;
        }
        else if (cam_mode == CamPersonMode.FirstPersonMode)
        {
            transform.position = player.transform.position;
        }
        else if (cam_mode == CamPersonMode.Ghost)
        {
            transform.position = player.transform.position - forw * distance;
        }
        
        
    }
    void RotateCam(Vector2 _mouse_axis)
    {
        _mouse_axis *= sensitivity / 10;
        _mouse_axis.y *= -1;
        if (cam_mode == CamPersonMode.ThirdPersonMode)
        {
            transform.RotateAround(player.transform.position, Vector3.up, _mouse_axis.x);
            transform.RotateAround(player.transform.position, transform.right, _mouse_axis.y);
        }
        else if (cam_mode == CamPersonMode.FirstPersonMode)
        {
            transform.Rotate(new Vector3(0, _mouse_axis.x, 0), Space.World);
            transform.Rotate(new Vector3(_mouse_axis.y, 0, 0), Space.Self);

        }
        else if (cam_mode == CamPersonMode.Ghost)
        {
            transform.RotateAround(player.transform.position, Vector3.up, _mouse_axis.x);
        }
    }
    private void Update()
    {
        CheckRotate();
        MoveCam();
    }
}
