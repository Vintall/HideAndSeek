using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProp : MonoBehaviour
{
    void Start()
    {
        
    }
    bool pressed = false;
    void FixedUpdate()
    {
        if (Input.GetAxis("ChangeProp") == 1 && !pressed) 
        {
            pressed = true;
            if (GetComponent<Select_Prop>().selected_prop != null)
            {
                GetComponent<Select_Prop>().selected_prop.SetActive(false);
            }
        } else if(Input.GetAxis("ChangeProp") == 0)
        {
            pressed = false;
        }
    }
}
