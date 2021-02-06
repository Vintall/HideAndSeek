using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject props; //Change!!!
    public static GameObject props_stat;

    // Start is called before the first frame update
    void Start()
    {
        props_stat = props;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
