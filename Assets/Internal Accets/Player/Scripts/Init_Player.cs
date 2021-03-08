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

                break;
            case Player_States.Player_Types.Seeker:

                break;
            case Player_States.Player_Types.Ghost:

                break;
        }
    }
}
