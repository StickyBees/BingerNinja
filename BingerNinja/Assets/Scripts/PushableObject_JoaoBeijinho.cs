﻿//Joao Beijinho

//Joao Beijinho 29/10/2020 - Created this scripted, collision and object attachment/detachment to player
//Joao Beijinho 30/10/2020 - Created m_isClose bool so that the player can only grab when its colliding
//Joao Beijinho 02/10/2020 - Replaced m_isClose with m_isGrabbed, removed collider.trigger and put collider.enable
//Joao Beijinho 09/11/2020 - Replaced tags with the tags in the Tags_JoaoBeijinho script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script makes it so that the player can grab and move an object, it stops moving after the player stops grabbing
/// </summary>
public class PushableObject_JoaoBeijinho : MonoBehaviour
{
    protected PlayerController_JamieG m_playerControllerScript;

    private Transform m_playerTransform;
    private BoxCollider2D m_collider; 
    
    public bool m_canGrab = false;
    public bool m_isGrabbed = false;

    private void Start()
    {
        m_playerTransform = GameObject.Find("Player").transform;
        m_playerControllerScript = FindObjectOfType<PlayerController_JamieG>();
        m_collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags_JoaoBeijinho.m_playerTag))
        {
            m_canGrab = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags_JoaoBeijinho.m_playerTag))
        {
            m_canGrab = false;
        }
    }

    void Update()
    {
        if (m_playerControllerScript.m_interact.triggered && m_canGrab == true)//Press interact to grab object and move it freely
        {
            m_canGrab = false;
            m_isGrabbed = true;
            transform.parent = m_playerTransform;
            Physics2D.IgnoreCollision(gameObject.transform.parent.GetComponent<Collider2D>(), m_collider);
        }
        else if (m_playerControllerScript.m_interact.triggered && m_isGrabbed == true)//Press interact to let go of object
        {
            m_canGrab = true;
            m_isGrabbed = false;
            Physics2D.IgnoreCollision(gameObject.transform.parent.GetComponent<Collider2D>(), m_collider, false);
            transform.parent = null;
        }
    }
}