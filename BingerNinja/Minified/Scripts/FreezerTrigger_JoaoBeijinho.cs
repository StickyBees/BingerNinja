using System.Collections.Generic;using UnityEngine;public class FreezerTrigger_JoaoBeijinho : M{public List<Collider2D> m_enemyList = new List<Collider2D>();void OnTriggerEnter2D(Collider2D a){if (a is BoxCollider2D && a.gameObject.CompareTag(Tags_JoaoBeijinho.m_enemyTag)){if (!m_enemyList.Contains(a)){m_enemyList.Add(a);}}}void OnTriggerExit2D(Collider2D b){if (b is BoxCollider2D && b.gameObject.CompareTag(Tags_JoaoBeijinho.m_enemyTag)){if (m_enemyList.Contains(b)){m_enemyList.Remove(b);}}}}