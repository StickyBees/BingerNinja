using UnityEngine;public class EnemyDamager_SebastianMol : M{public float XQ;internal float XW;public float XE = 0.5f;public float XR = 1;public float XT = 0.5f;public float XY = 5;void OnTriggerEnter2D(Collider2D b){if (b.tag == "Player"){FOT<PlayerHealthHunger_MarioFernandes>().j(XW);MeleeEnemy_SebastianMol a = GetComponentInParent<MeleeEnemy_SebastianMol>();if (a.CA == WU.WJ){if(a.QW){float I = Random.Range(0, 2);if (I > XE){FOT<EffectManager_MarioFernandes>().h(new PoisionDefuff_MarioFernandes(XR, XY));}else {FOT<EffectManager_MarioFernandes>().h(new SpeedEffect_MarioFernandes(XY, XT));}}}gameObject.SetActive(false);}}}