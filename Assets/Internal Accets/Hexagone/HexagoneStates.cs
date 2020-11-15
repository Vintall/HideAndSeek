using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagoneStates : MonoBehaviour
{
    // Start is called before the first frame update
    static double big_radius = 1;
    static double small_radius;
    public static float BigRadius
    {
        get
        {
            return (float)big_radius;
        }
    }
    public static float SmallRadius
    {
        get
        {
            return (float)small_radius;
        }
    }
    private void Awake()
    {
        small_radius = big_radius * Mathf.Cos(30);
    }
    void Start()
    {
        GetComponent<Transform>().localScale.Scale(new Vector3((float)big_radius, (float)big_radius));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
