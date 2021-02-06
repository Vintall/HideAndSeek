using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Prop : MonoBehaviour
{
    void Start()
    {
        
    }
    [SerializeField] Material red;
    [SerializeField] Material white;
    [SerializeField] float radius;
    RaycastHit hit_info;
    Ray raycast_ray;
    GameObject cur_game_obj; //Currently looked game object
    GameObject buf; //buffer
    public GameObject selected_prop = null;
    void FixedUpdate()
    {
        raycast_ray = new Ray(GetComponent<Move_Logic>().cam.transform.position, GetComponent<Move_Logic>().cam.transform.forward);
        if(Physics.Raycast(raycast_ray, out hit_info))
        {
            if (Vector3.Distance(hit_info.transform.position, GetComponent<Move_Logic>().cam.transform.position) <
                Vector3.Distance(GetComponent<Move_Logic>().cam.transform.position, transform.position))
            {
                GetComponent<Move_Logic>().cam.transform.position = hit_info.transform.position;
            }
            else
            {
                if (hit_info.transform.gameObject.transform.parent.name == "Props" && Vector3.Distance(hit_info.transform.position, transform.position) < radius)
                {
                    if (cur_game_obj != hit_info.transform.gameObject)
                    {
                        buf = cur_game_obj;
                        cur_game_obj = hit_info.transform.gameObject;
                        buf.GetComponent<MeshRenderer>().material = white;
                    }
                    else
                    {
                        hit_info.transform.gameObject.GetComponent<MeshRenderer>().material = red;
                        selected_prop = hit_info.transform.gameObject;
                    }

                } else if (cur_game_obj != null)
                {
                    cur_game_obj.GetComponent<MeshRenderer>().material = white;
                    cur_game_obj = null;
                    selected_prop = null;
                }
            }
        }
    }
}