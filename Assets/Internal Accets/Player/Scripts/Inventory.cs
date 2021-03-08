using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryCell[] inventory;
    public int active_cell;
    public class InventoryCell
    {
        public GameObject item;
        public bool have_item;
        public InventoryCell()
        {
            have_item = false;
        }
        public InventoryCell(GameObject item)
        {
            this.item = item;
            have_item = true;
        }
    }
    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(!inventory[i].have_item)
            {
                inventory[i] = new InventoryCell(item);
                Destroy(item);
                Debug.Log("PickUp Item " + item.name);
                break;
            }
        }
    }
    void Start()
    {
        inventory = new InventoryCell[5];
        for (int i = 0; i < inventory.Length; i++)
            inventory[i] = new InventoryCell();
    }

    
    void Update()
    {
        
    }
}
