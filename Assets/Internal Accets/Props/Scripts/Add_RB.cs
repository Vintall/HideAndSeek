using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_RB : MonoBehaviour
{
    void Start()
    {
        AddRigidBody();
    }
    public void AddRigidBody()
    {
        float mass = 1;
        mass = GetComponent<PropsState>().Mass;
        if (gameObject.transform.parent.name == "Props")
        {
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().mass = mass;
        }
        else if (gameObject.transform.parent.name == "PlayerProp")
            gameObject.transform.parent.transform.parent.GetComponent<Rigidbody>().mass = mass;
    }
}
