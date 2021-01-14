using System;using System.Collections;using System.Collections.Generic;using System.Linq;using UnityEngine;using UnityEngine.SceneManagement;using UnityEngine.UI;public class DialogueManager_MarioFernandes : M{public GameObject m_dialogBox;public Text m_nameText;public Text m_dialogueText;public float m_TextAnimationSpeed = 0;Queue<string> q;public TextAsset m_csvFile;public TextAsset m_csvFilePortuguese;string w = "DialogTrigger";PlayerController_JamieG e;GameObject[] r;WeaponUI_LouieWilliamson t;bool y = false;public void LoadLanguageFile(){WT u = SaveLoadSystem_JamieG.QU();if(u.QO != null && u.QO.Equals("Portuguese")){m_csvFile = m_csvFilePortuguese;};LoadDialog(SceneManager.GetActiveScene().buildIndex);}public void StartDialogue(Dialogue i){t.QF(false);PauseGame();m_dialogBox.SetActive(true);m_nameText.text = i.m_name;q.Clear();foreach (string o in i.m_sentences){q.Enqueue(o);}DisplayNextSentence();}public void DisplayNextSentence(){if(y){y = !y;}else{if (q.Count == 0){EndDialogue();return;}string p =  q.Dequeue();string a = "";if(p.Length > 181){for (int i = 181; i < p.Length; i++){a += p.ToCharArray()[i];}q.Enqueue(a);}StopAllCoroutines();SC(TypeSentence(p));}}IEnumerator TypeSentence(string s){PlayTrack_Jann.Instance.EM(AudioFiles.Sound_DialogSFX);y = true;m_dialogueText.text = "";foreach (char d in s.ToCharArray()){if(d == ' ')PlayTrack_Jann.Instance.EM(AudioFiles.Sound_DialogSFX);m_dialogueText.text += d;yield return new WaitForSeconds(m_TextAnimationSpeed);if(!y){m_dialogueText.text = s;break;}}y = false;}void EndDialogue(){m_dialogBox.SetActive(false);t.QF(true);ResumeGame();}void LoadDialog(int f = 0){GameObject g;GameObject h;string[] j = m_csvFile.text.Split("\n"[0]);for (int i = 0; i < j.Length; i++){List<string> k = j[i].Split((char)9).ToList();if (k[0] == f.ToString()){for (int e = k.Count - 1; e >= 0; e--){if (k[e] == "" || k[e][0] == (char)13){k.RemoveAt(e);}}h = null;g = null;g = F(k[1]);h = g.transform.Find(w)?.gameObject;if (h){DialogueTrigger_MarioFernandes l = h.GetComponent<DialogueTrigger_MarioFernandes>();if(l){l.m_dialogue.m_name = k[2];k.RemoveRange(0, 3);l.m_dialogue.m_sentences = k.ToArray();}}else if (g.GetComponent<BossDialogue_MarioFernandes>()){Dialogue a = new Dialogue();a.m_name = k[2];k.RemoveRange(0, 3);a.m_sentences = k.ToArray();g.GetComponent<BossDialogue_MarioFernandes>().m_dialogue.Add(a);}}}}public void PauseGame(){e.OnDisable();e.GetComponentInParent<PlayerHealthHunger_MarioFernandes>().m_paused = true;e.GetComponentInParent<EffectManager_MarioFernandes>().m_paused = true;r = GameObject.FindGameObjectsWithTag("Enemy");foreach (GameObject Enemy in r){Enemy.GetComponentInParent<BaseEnemy_SebastianMol>().enabled = false;}}public void ResumeGame(){e.OnEnable();e.GetComponentInParent<PlayerHealthHunger_MarioFernandes>().m_paused = false;e.GetComponentInParent<EffectManager_MarioFernandes>().m_paused = false;r = GameObject.FindGameObjectsWithTag("Enemy");foreach (GameObject ç in r){ç.GetComponentInParent<BaseEnemy_SebastianMol>().enabled = true;}}void Start(){m_dialogBox = m_nameText.transform.parent.gameObject;e = FOT<PlayerController_JamieG>();t = F("WeaponsUI").GetComponent<WeaponUI_LouieWilliamson>();q = new Queue<string>();LoadDialog(SceneManager.GetActiveScene().buildIndex);LoadLanguageFile();}void Update() {if(m_dialogBox.active && e.m_passDialogue.triggered){DisplayNextSentence();}}}[Serializable]public struct Dialogue{public string m_name;[TextArea(3, 10)]public string[] m_sentences;}