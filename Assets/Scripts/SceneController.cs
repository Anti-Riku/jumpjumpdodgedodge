﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SceneController : MonoBehaviour {

    public GameObject player;

    //Pregame configurations
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this);
	}

    //Physics!
    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    //Updating the things that need to be updated last, ex. map.
    void LateUpdate()
    {
        
    }

    //Used for scene dependent GUI items, such as map
    void OnGUI()
    {
       
    }
}