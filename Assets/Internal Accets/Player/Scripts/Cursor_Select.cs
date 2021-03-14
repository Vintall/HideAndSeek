using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Select : MonoBehaviour
{
    [SerializeField] Material red;
    [SerializeField] Material white;
    [SerializeField] float radius; //Distanse from player pos to raycast_hit

    bool item_pressed = false;
    bool prop_pressed = false;

    GameObject selected_object = null; //raycast_hit gameobject
    enum ObjType
    {
        None,
        Prop,
        Item,
    }
    RaycastHit hit_info;
    Ray raycast_ray;
    ObjType obj_type;

    private void Start()
    {
        
    }

    void VisualSelect()
    {
        selected_object.GetComponent<MeshRenderer>().material.SetFloat("_Outline", SettingsManager.manager.GetComponent<Settings_Pointers>().settings.outline_heigth);
        selected_object.GetComponent<MeshRenderer>().material.SetColor("_OutlineColor", new Color(SettingsManager.manager.GetComponent<Settings_Pointers>().settings.outline_color_r, SettingsManager.manager.GetComponent<Settings_Pointers>().settings.outline_color_g, SettingsManager.manager.GetComponent<Settings_Pointers>().settings.outline_color_b));
    }
    void VisualUnSelect()
    {
        selected_object.GetComponent<MeshRenderer>().material.SetInt("_Outline", 0);
    }
    void FixedUpdate()
    {
        raycast_ray = new Ray(Player_Cam_Singleton.cam.position, Player_Cam_Singleton.cam.forward);

        if (selected_object != null)
            VisualUnSelect();
        selected_object = null;
        obj_type = ObjType.None;

        if (Physics.Raycast(raycast_ray, out hit_info) && Vector3.Distance(hit_info.point, transform.position) < radius) 
        {
            if (hit_info.transform.GetComponentInParent<Props>() != null)
            {
                PropSelect();
            }
            else if (hit_info.transform.GetComponentInParent<Items>() != null)
            {
                ItemSelect();
            }
        }

        void PropSelect()
        {
            selected_object = hit_info.transform.gameObject;
            VisualSelect();
            obj_type = ObjType.Prop;
        }
        void ItemSelect()
        {
            selected_object = hit_info.transform.gameObject;
            VisualSelect();
            obj_type = ObjType.Item;
        }

        if (Input.GetAxis("PickUp") == 1 && !item_pressed && obj_type == ObjType.Item)
        {
            item_pressed = true;
            GetComponent<Pick_Up_Item>().PickUpItem(selected_object);
        }
        else if(Input.GetAxis("PickUp") == 0)
            item_pressed = false;

        if (Input.GetAxis("ChangeProp") == 1 && !prop_pressed && obj_type == ObjType.Prop)
        {
            prop_pressed = true;
            GetComponent<Swap_Prop>().Swap(selected_object);
        }
        else if (Input.GetAxis("ChangeProp") == 0)
            prop_pressed = false;
    }
}