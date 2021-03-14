using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] Sprite icon;

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }
}
