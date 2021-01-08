﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_RB : MonoBehaviour
{
    [SerializeField] float mass;
    void Start()
    {
        if (gameObject.transform.parent.name == "Props")
        {
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().mass = mass;
        } else if(gameObject.transform.parent.name == "PlayerProp")
            gameObject.transform.parent.transform.parent.GetComponent<Rigidbody>().mass = mass;
    }
    void Update()
    {
        
    }
}