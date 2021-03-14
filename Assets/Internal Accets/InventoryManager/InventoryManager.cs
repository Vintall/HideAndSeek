using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager manager;
    public const int InventoryLength = 5;
    public GameObject panel;
    int current_cell;

    public int CurrentCell
    {
        get
        {
            return current_cell;
        }
        set
        {
            if (value <= 0)
            {
                current_cell = 1;
            }
            else if (value > InventoryLength)
            {
                current_cell = InventoryLength;
            }
            else
            {
                current_cell = value;
            }
        }
    }
    void Start()
    {
        manager = this;
        current_cell = 1;
    }

    public void SetCellSprite(int cell_num, Sprite sprite)
    {
        panel.GetComponent<InventoryUI>().cells[cell_num].GetComponent<Image>().sprite = sprite;
    }

    void SetCellsActive(int cell_num)
    {
        cell_num--;
        for (int i = 0; i < InventoryLength; i++)
        {
            panel.GetComponent<InventoryUI>().cells[i].transform.GetChild(0).gameObject.SetActive(false);
            if (cell_num == i)
            panel.GetComponent<InventoryUI>().cells[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetAxis("Inventory_1") == 1) 
        {
            current_cell = 1;
            SetCellsActive(current_cell);
        }
        else if (Input.GetAxis("Inventory_2") == 1)
        {
            current_cell = 2;
            SetCellsActive(current_cell);
        }
        else if (Input.GetAxis("Inventory_3") == 1)
        {
            current_cell = 3;
            SetCellsActive(current_cell);
        }
        else if (Input.GetAxis("Inventory_4") == 1)
        {
            current_cell = 4;
            SetCellsActive(current_cell);
        }
        else if (Input.GetAxis("Inventory_5") == 1)
        {
            current_cell = 5;
            SetCellsActive(current_cell);
        }
    }
}
