﻿using System.Collections;
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
    void Start()
    {

    }

    
    void Update()
    {
        
    }
}