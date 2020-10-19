﻿//Joao Beijinho
///This class handles interaction with phone, makes player stealth for a while but unable to move

//Joao Beijinho 18/10/2020 - Created draft for Phone interaction, making the player stealth and unable to move for a few seconds
//Joao Beijinho 19/10/2020 - Updated Movement restriction using PlayerController, and now the player can move after a specific set of time

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone_JoaoBeijinho : MonoBehaviour
{
    StealthObject_JoaoBeijinho steathObjectScript;
    PlayerController_JamieG playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        steathObjectScript = FindObjectOfType<StealthObject_JoaoBeijinho>();
        playerControllerScript = FindObjectOfType<PlayerController_JamieG>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(PhoneDuration());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    //Time for stealth and movement restriction while on phone, resume after a set time
    IEnumerator PhoneDuration()
    {
        steathObjectScript.Hide();
        playerControllerScript.m_movement.Disable();

        yield return new WaitForSeconds(5);

        steathObjectScript.Hide();
        playerControllerScript.m_movement.Enable();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
}