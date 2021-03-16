using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_States : MonoBehaviour
{
    [SerializeField] Transform hider_obj;
    [SerializeField] Transform seeker_obj;

    public Transform HiderObj
    {
        get
        {
            return hider_obj;
        }
    }
    public Transform SeekerObj
    {
        get
        {
            return seeker_obj;
        }
    }
    public enum Player_Types
    {
        Hider,
        Seeker,
        Ghost
    }
    [SerializeField] Player_Types player_type;
    public Player_Types PlayerType
    {
        get
        {
            return player_type;
        }
    }
    void Start()
    {

    }

    
    void Update()
    {
        
    }
}
