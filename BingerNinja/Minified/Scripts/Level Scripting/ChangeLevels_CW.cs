using UnityEngine;using UnityEngine.SceneManagement;public class ChangeLevels_CW : M{public GameObject vendingMachine;protected Inventory_JoaoBeijinho m_Inventory;void Awake(){m_Inventory = FOT<Inventory_JoaoBeijinho>();}void OnTriggerEnter2D(Collider2D a){if(a.tag == "Player"){m_Inventory.RG(ItemType.NinjaPoints, 15);int b = SceneManager.GetActiveScene().buildIndex;if (b % 3 == 0 || b == 20){SaveLoadSystem_JamieG.SaveCheckpoint(b + 1);}if (b > 4 && b != 20){vendingMachine.SetActive(true);Time.timeScale = 0f;VendingMachineMenu_Elliott.m_gameIsPaused = true;}else {ProgressToNextLevel();}}}public void ProgressToNextLevel(){Time.timeScale = 1f;VendingMachineMenu_Elliott.m_gameIsPaused = false;SceneManager_JamieG.Instance.LoadNextLevel();}public void ReturnToMenu(){SceneManager.LoadScene("ElliottDesouza_MainMenu");SaveLoadSystem_JamieG.DeleteSaves();}}