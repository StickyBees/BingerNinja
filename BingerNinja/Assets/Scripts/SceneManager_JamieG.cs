﻿//Jamie - Functions used to load different scenes

//Jamie - 26/10/20 - First implemented
// Jann - 06/11/20 - Hooked up the savesystem and the checkpoints
// Jann - 14/12/20 - New ResetToCheckpoint implementation

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// IMPORTANT - Correct scene order must be setup in projects build settings scene index
/// </summary>
public class SceneManager_JamieG : Singleton_Jann<SceneManager_JamieG>
{
    private GameObject m_player;
    private Vector3 m_checkpointOnReset;
    private bool m_loadLastCheckpoint = false;

    public void ResetLevel()
    {
        LoadCurrentLevel();
    }

    public void ResetToCheckpoint()
    {
        int checkpointLevel = SaveLoadSystem_JamieG.LoadCheckpoint().m_lastCheckpointLevel;
        LoadLevel(checkpointLevel > 0 ? checkpointLevel : 1);
    }

    //This will assume that the MainMenu scene is build index 0
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); 
    }

    //Assumes that the scenes are in the correct order of build indexes in build settings
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Reloads the current scene using its buildIndex
    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //This is called everytime a scene is loaded
    //It moves the player to the last checkpoint if m_loadLastCheckpoint is true
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!m_loadLastCheckpoint)
        {
            return;
        }
        
        LoadGameState();
        
        if (m_player == null)
        {
            m_player = GameObject.FindWithTag("Player");
        }

        m_player.transform.position = m_checkpointOnReset;

        m_loadLastCheckpoint = false;
    }

    public void SaveGameState()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            Inventory_JoaoBeijinho inventory = player.GetComponent<Inventory_JoaoBeijinho>();
            SaveLoadSystem_JamieG.SaveInventory(inventory);
            
            SaveLoadSystem_JamieG.SaveGameplay(
                SceneManager.GetActiveScene().buildIndex,
                GameObject.FindGameObjectsWithTag("Enemy"),
                new GameObject[0]//GameObject.FindGameObjectsWithTag("Door")
            );
        }
    }
    
    public void LoadGameState()
    {
        GameplayData gameplayData = SaveLoadSystem_JamieG.LoadGameplay();
        
        // Load enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            if (!gameplayData.m_enemyIds.Contains(enemy.name))
            {
                enemy.SetActive(false);
            }
        }
    }
}
