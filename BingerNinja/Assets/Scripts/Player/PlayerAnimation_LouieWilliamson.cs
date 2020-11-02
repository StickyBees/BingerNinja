﻿///Louie Williamson
///This script handles the animation states of the player and communicated with the player animation controller to do so.

//Louie 02/11/2020 - First created

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation_LouieWilliamson : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isFacingLeft;
    private Animator m_playerAnim;
    private Rigidbody2D m_rb;

    public void TriggerAttackAnim()
    {
        m_playerAnim.SetTrigger("isAttacking");
    }
    void Start()
    {
        isFacingLeft = true;

        m_playerAnim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Is he moving?
        if (m_rb.velocity.x != 0 || m_rb.velocity.y != 0)
        {
            m_playerAnim.SetTrigger("isMoving");
        }
        else
        {
            m_playerAnim.SetTrigger("isIdle");
        }

        //Is he moving to the left
        if (m_rb.velocity.x < 0)
        {
            //is he already facing left?
            if (!isFacingLeft)
            {
                //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                FlipSprite();
                isFacingLeft = true;
            }
        }
        else
        {
            if (isFacingLeft)
            {
                //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                FlipSprite();
                isFacingLeft = false;
            }
        }

        //Is he moving upwards
        if (m_rb.velocity.y < 0)
        {
            m_playerAnim.SetBool("isFacing" , true);
        }
        else if (m_rb.velocity.y > 0)
        {
            m_playerAnim.SetBool("isFacing", false);
        }
        
    }
    private void FlipSprite()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
