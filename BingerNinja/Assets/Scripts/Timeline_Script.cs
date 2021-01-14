﻿using UnityEngine;
using UnityEngine.Playables;
public class Timeline_Script : MonoBehaviour
{
    public PlayableDirector[] timeline;
    public PlayableDirector playableDirector;
    public GameObject nextButton, dialogBox, tadashi, ninjaroth, leftButton, rightButton;
    public bool playerMadeChoice = false;
    void Awake()
    {
        playableDirector = timeline[0];
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }  
    void Update()
    {
        // if (waited)
        // {
        //     if (!dialogBox.activeInHierarchy)
        //     {
        //         playableDirector.Stop();
        //     }
        // }
    }
    public void PlayTimeline()
    {
        if (playableDirector != null)
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
        //nextButton.SetActive(false);
    }
    public void PauseTimeline()
    {
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
       // nextButton.SetActive(true);
       if (dialogBox.activeInHierarchy == false)
            {
                playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(5);
                //playableDirector.Stop();
            }
    }
    public void ChangeDirector(string directorName = "Good Ending / Bad Ending")
    {
        if (directorName == "Good Ending")
        {
            playableDirector = timeline[1];
            playableDirector.Play();
        }
        if (directorName == "Bad Ending")
        {
            playableDirector = timeline[2];
            playableDirector.Play();
        }
    }
    public void ButtonsVisible()
    {
        leftButton.SetActive(true);
        rightButton.SetActive(true);
    }
    public void ButtonsInVisible()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
    }
    public void Tadashi()
    {
        playerMadeChoice = true;
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(10);
        dialogBox.SetActive(false);
        dialogBox.GetComponentInParent<DialogueManager_MarioFernandes>().W();
        tadashi.SetActive(true);
        ninjaroth.SetActive(false);

    }
    public void Ninjaroth()
    {
        playerMadeChoice = true;
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(10);
        dialogBox.SetActive(false);
        dialogBox.GetComponentInParent<DialogueManager_MarioFernandes>().W();
        tadashi.SetActive(false);
        ninjaroth.SetActive(true);

    }
     public void RandomChoice()
     {
        if (!playerMadeChoice)
        {
            int i = Random.Range(0,10);
            if (i >=4)
            {
                tadashi.SetActive(true);
                ninjaroth.SetActive(false);
            }
            else
            {
                tadashi.SetActive(false);
                ninjaroth.SetActive(true);
            }
            dialogBox.SetActive(false);
            dialogBox.GetComponentInParent<DialogueManager_MarioFernandes>().W();

        }
        else
            return;

     }
        
    
}
