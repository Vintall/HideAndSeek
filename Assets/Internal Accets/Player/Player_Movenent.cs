using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movenent : MonoBehaviour
{
    Vector3 speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 0);
    }
    Vector3 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.y = 5;
        }
        speed = movement;
        rb.AddForce(speed);
    }
}
