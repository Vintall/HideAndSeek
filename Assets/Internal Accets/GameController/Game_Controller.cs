using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject props; //Change!!!
    public GameObject player;
    public GameObject cam;

    void Start()
    {
        Player_Cam_Singleton.cam = cam.transform;
        Player_Cam_Singleton.player = player.transform;
        Player_Cam_Singleton.have_cam = true;
    }

    void Update()
    {
        
    }
}
