using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject[] cells;
    void Start()
    {
        cells = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            cells[i] = transform.GetChild(i).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
