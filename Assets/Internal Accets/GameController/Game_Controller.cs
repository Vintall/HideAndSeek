using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject props; //Change!!!
    public GameObject player;
    public GameObject cam;

    private void Awake()
    {
        Player_Cam_Singleton.cam = cam.transform;
        Player_Cam_Singleton.player = player.transform;
        Player_Cam_Singleton.have_cam = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
