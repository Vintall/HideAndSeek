using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Item : MonoBehaviour
{
    public void PickUpItem(GameObject item)
    {
        if (GetComponent<Player_States>().PlayerType != Player_States.Player_Types.Hider)
            return;

        GetComponent<Inventory>().AddItem(item);
    }
}
