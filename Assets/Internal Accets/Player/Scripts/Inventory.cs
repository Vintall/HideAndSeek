using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public InventoryCell[] inventory;
    public class InventoryCell
    {
        public GameObject item;
        public bool have_item;
        public bool locked;
        public InventoryCell()
        {
            have_item = false;
            locked = false;
        }
        public InventoryCell(GameObject item)
        {
            this.item = item;
            have_item = true;
            locked = false;
        }
    }
    
    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(!inventory[i].have_item)
            {
                inventory[i] = new InventoryCell(item);

                //Destroy(item);
                item.SetActive(false);    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Правильно ли?

                Debug.Log("PickUp Item " + item.name);
                InventoryManager.manager.SetCellSprite(i, item.GetComponent<Item>().Data.Icon);
                
                break;
            }
        }
    }
    public void UseItem()
    {
        inventory[InventoryManager.manager.CurrentCell - 1].item.GetComponent<Item>().Use();
    }
    void Start()
    {
        inventory = new InventoryCell[5];
        for (int i = 0; i < inventory.Length; i++)
            inventory[i] = new InventoryCell();
    }

    
    void Update()
    {
        if (Input.GetAxis("UseItem") == 1)
        {
            UseItem();
        }
    }
}
