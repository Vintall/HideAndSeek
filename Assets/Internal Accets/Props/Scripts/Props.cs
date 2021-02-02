using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    [SerializeField] GameObject[] props;
    void Start()
    {
        props = GameObject.FindGameObjectsWithTag("Prop");
    }
}