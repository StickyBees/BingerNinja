using UnityEngine;public class ControlPanel_JoaoBeijinho : M{protected PlayerController_JamieG m_playerControllerScript;public ControlPanelActivateObject_JoaoBeijinho[] m_activateObjectScript;public bool m_canPressButton = false;void OnTriggerEnter2D(Collider2D a){if (a.gameObject.CompareTag(Tags_JoaoBeijinho.QK)){m_canPressButton = true;}}void OnTriggerExit2D(Collider2D b){if (b.gameObject.CompareTag(Tags_JoaoBeijinho.QK)){m_canPressButton = false;}}void Awake(){m_playerControllerScript = FOT<PlayerController_JamieG>();}void Update(){if (m_playerControllerScript.m_interact.triggered && m_canPressButton){for (int i = 0; i < m_activateObjectScript.Length; i++){m_activateObjectScript[i].ActivateObject();}}}}