using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItemAbility
{
    void Use();
}
public class ItemAbility : MonoBehaviour
{
    public virtual void Use()
    {
        Debug.Log("ItemAbility class use");
    }
}
public class Item : MonoBehaviour
{
    [SerializeField] ItemAbility ability_component;
     
    [SerializeField] ItemData data;
    public ItemData Data
    {
        get
        {
            return data;
        }
    }
    public void Use()
    {
        ability_component.Use();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
