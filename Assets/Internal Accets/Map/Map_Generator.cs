using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Map_Generator : MonoBehaviour
{
    [SerializeField] Map map_script;
    [SerializeField] GameObject hex;
    [SerializeField] int x = 1, y = 1;
    [SerializeField] float high_radius = 1;
    float low_radius;
    void GenerateMap()
    {
        
        GameObject cur;
        Quaternion qua = new Quaternion();
        qua.eulerAngles = new Vector3(-90, 90, 0);
        for (int i_y = 0; i_y < y; i_y++)
        {
            for (int i_x = 0; i_x < x; i_x++)
            {
                map_script.hex_grid[i_x, i_y] = new Vector2((float)(i_x * high_radius * 3f / 2), (float)(low_radius * (2 * i_y - i_x % 2)));
                cur = Instantiate(hex, new Vector3(map_script.hex_grid[i_x, i_y].x, 0, map_script.hex_grid[i_x, i_y].y), qua);
                cur.transform.parent = transform;
            }
        }
    }
    void Start()
    {
        low_radius = high_radius * Mathf.Sqrt(3) / 2;
        map_script.hex_grid = new Vector2[x, y];

        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
