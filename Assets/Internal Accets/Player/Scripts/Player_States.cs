using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_States : MonoBehaviour
{
    enum Player_Types
    {
        Hider,
        Seeker,
        Ghost
    }
    [SerializeField] Player_Types player_type;
    [SerializeField] GameObject prop;
    public GameObject Prop
    {
        get
        {
            return prop;
        }
        set
        {
            prop = value;
        }
    }
    void Start()
    {

    }

    
    void Update()
    {
        
    }
}
