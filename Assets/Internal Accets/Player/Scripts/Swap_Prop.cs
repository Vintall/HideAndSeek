using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Prop : MonoBehaviour
{
    public void Swap(GameObject obj)
    {
        if (GetComponent<Player_States>().PlayerType != Player_States.Player_Types.Hider)
            return;

        Transform player_prop_box = GetComponent<Player_States>().HiderObj.Find("PlayerProp");

        Transform player_prop = player_prop_box.transform.GetChild(0);

        Rigidbody prop_rb = obj.transform.gameObject.GetComponent<Rigidbody>();
        Rigidbody player_rb = GetComponent<Rigidbody>();

        Vector3 player_velocity = player_rb.velocity;
        Quaternion player_rotation = player_rb.rotation;

        GetComponent<Rigidbody>().velocity = prop_rb.velocity; //Take data from prop RigidBody to Player RB
        GetComponent<Rigidbody>().rotation = prop_rb.rotation;


        Destroy(obj.GetComponent<Rigidbody>()); //Remove RigidBody from Prop GameObject

        Vector3 player_pos = transform.position;
        Vector3 prop_pos = obj.transform.position;

        player_prop.position = player_pos;
        player_prop.parent = obj.transform.parent; //Change Player GameObject instance as prop

        obj.transform.parent = player_prop_box; //Give Prop a new parent inside the player

        player_prop.GetComponent<Add_RB>().AddRigidBody();

        player_prop.GetComponent<Rigidbody>().velocity = player_velocity;
        player_prop.GetComponent<Rigidbody>().rotation = player_rotation;

        GetComponent<Player_States>().HiderObj.Find("PlayerProp").transform.GetChild(0).transform.localPosition = Vector3.zero;
        transform.position = prop_pos;
    }
}
