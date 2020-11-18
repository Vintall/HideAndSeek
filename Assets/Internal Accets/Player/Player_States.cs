using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_States : MonoBehaviour
{
    enum Player_Types
    {
        Hider,
        Seeker,
        None
    }
    [SerializeField] Player_Types player_type;
    [SerializeField] GameObject player_model;
    [SerializeField] GameObject player_collider;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
