using System.Collections.Generic;using UnityEngine;public class BossDialogue_MarioFernandes : M{public List<Dialogue> m_dialogue;public void A (int i){if (i < m_dialogue.Capacity - 1 && i >= 0)FOT<DialogueManager_MarioFernandes>().StartDialogue(m_dialogue[i]);}}