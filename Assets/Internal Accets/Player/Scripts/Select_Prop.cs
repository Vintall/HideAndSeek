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
    GameObject cur_game_obj=null; //Currently looked game object
    GameObject buf; //buffer
    public GameObject selected_prop = null;

    bool pressed = false;
    struct ObjInfo
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 velocity;
        public ObjInfo(Vector3 position, Quaternion rotation, Vector3 velocity)
        {
            this.position = position;
            this.rotation = rotation;
            this.velocity = velocity;
        }

    }
    void FixedUpdate()
    {
        raycast_ray = new Ray(GetComponent<Move_Logic>().cam.transform.position, GetComponent<Move_Logic>().cam.transform.forward);
        if (Physics.Raycast(raycast_ray, out hit_info) && Vector3.Distance(hit_info.point, transform.position) < radius)
        {
            if (hit_info.transform.GetComponentInParent<Props>() != null)
            {
                if (cur_game_obj != hit_info.transform.gameObject)
                {
                    buf = cur_game_obj;
                    cur_game_obj = hit_info.transform.gameObject;
                    if(buf != null)
                    buf.GetComponent<MeshRenderer>().material = white;
                }
                else
                {
                    hit_info.transform.gameObject.GetComponent<MeshRenderer>().material = red;
                    selected_prop = hit_info.transform.gameObject;
                }

            }
            else if (cur_game_obj != null)
            {
                cur_game_obj.GetComponent<MeshRenderer>().material = white;
                cur_game_obj = null;
                selected_prop = null;
            }
        }

        if (Input.GetAxis("ChangeProp") == 1 && !pressed)
        {
            pressed = true;
            if (GetComponent<Select_Prop>().selected_prop != null)
            {
                Transform player_prop = transform.Find("PlayerProp").transform.GetChild(0);
                Rigidbody prop_rb = selected_prop.GetComponent<Rigidbody>();
                Rigidbody player_rb = GetComponent<Rigidbody>();

                Vector3 player_velocity = player_rb.velocity;
                Quaternion player_rotation = player_rb.rotation;

                GetComponent<Rigidbody>().velocity = prop_rb.velocity; //Take data from prop RigidBody to Player RB
                GetComponent<Rigidbody>().rotation = prop_rb.rotation;


                Destroy(selected_prop.GetComponent<Rigidbody>()); //Remove RigidBody from Prop GameObject

                Vector3 player_pos = transform.position;
                Vector3 prop_pos = selected_prop.transform.position;

                player_prop.position = player_pos;
                player_prop.parent = Game_Controller.props_stat.transform; //Change Player GameObject instance as prop
                selected_prop.transform.parent = gameObject.transform.Find("PlayerProp"); //Give Prop a new parent inside the player
                player_prop.GetComponent<Add_RB>().AddRigidBody();

                player_prop.GetComponent<Rigidbody>().velocity = player_velocity;
                player_prop.GetComponent<Rigidbody>().rotation = player_rotation;

                transform.Find("PlayerProp").transform.GetChild(0).transform.localPosition = Vector3.zero;
                transform.position = prop_pos;

                selected_prop = null;
            }
        }
        else if (Input.GetAxis("ChangeProp") == 0)
        {
            pressed = false;
        }
    }
}