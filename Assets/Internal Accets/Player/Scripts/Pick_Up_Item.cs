﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Item : MonoBehaviour
{
    public void PickUpItem(GameObject item)
    {
        GetComponent<Inventory>().AddItem(item);
    }
}
