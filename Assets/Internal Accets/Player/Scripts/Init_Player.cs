using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Player : MonoBehaviour
{
    void Start()
    {
        InitPlayer();
    }
    
    public void InitPlayer()
    {
        switch(GetComponent<Player_States>().PlayerType)
        {
            case Player_States.Player_Types.Hider:
                Player_Cam_Singleton.cam.GetComponent<Cam_Movement>().cam_mode = Cam_Movement.CamPersonMode.ThirdPersonMode;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                break;
            case Player_States.Player_Types.Seeker:
                Player_Cam_Singleton.cam.GetComponent<Cam_Movement>().cam_mode = Cam_Movement.CamPersonMode.FirstPersonMode;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

                break;
            case Player_States.Player_Types.Ghost:
                Player_Cam_Singleton.cam.GetComponent<Cam_Movement>().cam_mode = Cam_Movement.CamPersonMode.FirstPersonMode;

                break;
        }
    }
}
