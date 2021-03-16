using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_Item : ItemAbility, IItemAbility
{
    public override void Use()
    {
        Debug.Log("Test_Item ability use");
        RaycastHit hit_info;
        if (Physics.Raycast(Player_Cam_Singleton.cam.position, Player_Cam_Singleton.cam.forward, out hit_info))
        {
            gameObject.transform.position = hit_info.point;
            gameObject.SetActive(true);
            
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
