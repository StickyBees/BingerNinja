﻿//Joao Beijinho

//Joao Beijinho 29/10/2020 - Created this scripted, collision and object attachment/detachment to player
//Joao Beijinho 30/10/2020 - Created m_isClose bool so that the player can only grab when its colliding

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script makes it so that the player can grab and move an object, it stops moving after the player stops grabbing
/// </summary>
public class PushableObject_JoaoBeijinho : MonoBehaviour
{
    protected PlayerController_JamieG m_playerControllerScript;

    private GameObject m_player;
    private BoxCollider2D m_collider; 

    private string m_playerTag = "Player";
    private bool m_isClose = false;
    private bool m_canGrab = false;

    private void Start()
    {
        m_player = GameObject.Find("Player");
        m_playerControllerScript = FindObjectOfType<PlayerController_JamieG>();
        m_collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == m_playerTag)
        {
            m_isClose = true;
            m_canGrab = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == m_playerTag)
        {
            m_isClose = false;
            m_canGrab = false;
        }
    }

    void Update()
    {
        if (m_playerControllerScript.m_interact.triggered && m_canGrab == true && m_isClose == true)//Press interact to grab object and move it freely
        {
            m_canGrab = false;
            gameObject.transform.parent = m_player.transform;
            m_collider.isTrigger = true;
        }
        else if (m_playerControllerScript.m_interact.triggered && m_canGrab == false && m_isClose == true)//Press interact to let go of object
        {
            m_canGrab = true;
            gameObject.transform.parent = null;
            m_collider.isTrigger = false;
        }
    }
}