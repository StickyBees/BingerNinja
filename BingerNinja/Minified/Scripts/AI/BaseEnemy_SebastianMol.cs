using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.Tilemaps;public enum WW { WE, WR, WT, WY };public enum WU { WI, WO, WP, WA, WS, WD, WF, WG, WH, WJ, WK, WL };public enum WZ { WX, WC, WV, WB };abstract class BaseEnemy_SebastianMol : M{public Transform a;public Transform b;public PolygonCollider2D CE;public bool CW = false;public WW CQ = WW.WE;public WU CA;public GameObject CR;public GameObject CT;public Inventory_JoaoBeijinho CY;public float CU;public GameObject CI;public float CO;public float CP;public bool CS = false;public Tilemap CD;public Transform[] CF;public float CG;public float CH;public bool CJ;public float CK;float m = 0.5f;public float X;public float C;public float V;public float B = 1f;public float N = 2;public float M = 0.3f;public float QQ = 3;public bool QW = true;public float QE = 1.5f;internal float QR;Pathfinder_SebastianMol q;protected List<Vector2Int> QT = new List<Vector2Int>();protected Transform QY;protected float QU;Vector3 w;protected Vector3 QI;protected float QO;protected float QP;protected int QA = 0;protected float QS;int e;float r;Transform t;Vector3 y;protected bool QD = false;float u;bool i = false;Vector3 o;protected int QF = 1;CameraShakeElliott s;protected bool QG = false;PlayerSpoted_Elliott d;protected PlayerStealth_JoaoBeijinho QH;int f = 1 << 8;void g(){if (CJ){WM();}else {CE.enabled = true;if (Vector2.Distance(transform.position, QI) > 0.5f){EQ(QI);}if(Vector2.Distance(transform.position, QI) <= 0.5f) transform.localScale = new Vector3(QU, transform.localScale.y, transform.localScale.z);}QG = false;}void h(){if (EW()){if (Vector2.Distance(transform.position, QY.position) < V / B){EE(false);CQ = WW.WT;}else {EQ(QY.position);}}else {ER();i = true;if (QT.Count == 0){if (QP <= 0){i = false;CQ = WW.WE;CW = false;}else {j();QP -= Time.deltaTime;}}}}void j(){if(m <= 0){if(transform.localScale.x > 0){transform.localScale = new Vector3(-QU, transform.localScale.y, transform.localScale.z);}else {transform.localScale = new Vector3(QU, transform.localScale.y, transform.localScale.z);}m = u;}else {m -= Time.deltaTime;}}abstract internal void ET();void k(){if (EW()){if (Vector2.Distance(transform.position, QY.position) < V){ET();}else {CQ = WW.WR;}QP = CK;CW = true;}else {CW = false;if (QP <= 0){CQ = WW.WE;}else {QP -= Time.deltaTime;}}}void l(){if (Vector2.Distance( transform.position, o) < 1 )if (QP <= 0){CQ = WW.WE;QP = CK;}else {QP -= Time.deltaTime;ER();}}void z(){switch (CQ){case WW.WE:g();break;case WW.WR:h();break;case WW.WT:k();break;case WW.WY:l();break;}}protected void EY(GameObject EI){if(EI.CompareTag("Player")){PlayerStealth_JoaoBeijinho EU = EI.GetComponent<PlayerStealth_JoaoBeijinho>();if (CA == WU.WF){if(!EU.H()){x(EI);}}else if(!EU.F()){x(EI);}}}void x(GameObject EO){CE.enabled = false;RaycastHit2D EP = Physics2D.Linecast(a.position, EO.transform.position);if (!QH.G() && EP.collider.gameObject.CompareTag(Tags_JoaoBeijinho.QK)){CW = true;QY = EP.transform;CQ = WW.WT;EA();EE();}else {CE.enabled = true;}}protected bool EW(){if (QY){CE.enabled = false;RaycastHit2D ES = Physics2D.Linecast(a.position, QY.position);if (ES.collider.gameObject.CompareTag("Player")){CE.enabled = false;return true;}else {RaycastHit2D ED = Physics2D.Linecast(b.position, QY.position);if (ED.collider.gameObject.CompareTag("Player")){CE.enabled = false;return true;}else {CE.enabled = true;return false;}}}return false;}protected void EF(Vector3 EG){Vector2Int EH = (Vector2Int)q.QB.WorldToCell(transform.position);Vector2Int EJ = (Vector2Int)q.QB.WorldToCell(EG);QT = q.WE(EH, EJ);if(CS){for (int i = 0; i < QT.Count; i++){CD.SetTileFlags(new Vector3Int(QT[i].x, QT[i].y, 0), TileFlags.None);CD.SetColor(new Vector3Int(QT[i].x, QT[i].y, 0), Color.green);}}}protected void EK(){if (QT.Count == 0) return;float EL = CP * Time.deltaTime;while (EL > 0){Vector2 EZ = (Vector2)q.QB.CellToWorld(new Vector3Int( QT[0].x, QT[0].y, 0)) + ((Vector2)q.QB.cellSize / 2);EZ += new Vector2(-0.5f, 0);float EX = Vector2.Distance(transform.position, EZ);if (EX > EL){transform.position = Vector2.MoveTowards(transform.position, EZ, EL);EL = 0;}else{transform.position = Vector2.MoveTowards(transform.position, EZ, EX);EL -= EX;if (CS) CD.SetColor(new Vector3Int(QT[0].x, QT[0].y, 0), Color.white);QT.RemoveAt(0);if (QT.Count == 0) break;}}}protected void EE(bool EC = true){if (CS){for (int i = 0; i < QT.Count; i++){CD.SetColor(new Vector3Int(QT[i].x, QT[i].y, 0), Color.white);}}QT.Clear();if(EC) QT.Add((Vector2Int)q.QB.WorldToCell(transform.position));y = Vector3.zero;}protected void WM(){if (t == null) return;if (t.position.x == 0 && t.position.y == 0) t = CF[0];if (QT.Count == 0) EF(CF[QA].position);if (Vector2.Distance(transform.position, CF[QA].position) <= 0.4f) EV();EK();}protected void EV(){if(CF.Length > 0){if (r <= 0){if (QA == e){QA = 0;t = CF[QA];}else {t = CF[++QA];}r = CH;}else {r -= Time.deltaTime;}}}protected void EQ(Vector3 pos){if (QT.Count == 0){EF(pos);}if (y == Vector3.zero){y = pos;}if (Vector2.Distance(y, pos) > CG){EE();EF(pos);}EK();}public void EB(){if(CO <= 0){PlayTrack_Jann.Instance.EM(AudioFiles.Sound_Damage);if (CI){Instantiate(CI, transform.position, Quaternion.identity);}gameObject.SetActive(false);CY.EN();}}protected void RQ(){if(!i)if(CW){if(QY.position.x > transform.position.x){transform.localScale = new Vector3( -QU, transform.localScale.y, transform.localScale.z);}else {transform.localScale = new Vector3(QU, transform.localScale.y, transform.localScale.z);}}else {if(w.x > transform.position.x){transform.localScale = new Vector3(QU, transform.localScale.y, transform.localScale.z);}else if(w.x < transform.position.x){transform.localScale = new Vector3(-QU, transform.localScale.y, transform.localScale.z);}w = transform.position;}}public void RW(WZ RE, float RR){switch (CA){case WU.WI:v(RR);break;case WU.WO:if (RE == WZ.WX){v(RR * 1.5f);}else {v(RR);}break;case WU.WL:break;case WU.WP:if(QY.position.x < transform.position.x){if(transform.localScale.x < 0) v(RR);}else if(QY.position.x > transform.position.x){if (transform.localScale.x > 0) v(RR);}else {v(RR*0.25f);}break;case WU.WS:if (RE == WZ.WX){if(CW == false){v(RR);}else{v(RR * 0.5f);}}else {v(RR);}break;case WU.WD:case WU.WA:Debug.Log(CW);if (CW == false){CO -= RR * (X + C);}else {CO -= RR;}break;case WU.WJ:if ((CO / QR) <= M){v(RR);QO *= QE;QW = false;C = 0;}else {if (CW == false){CO -= RR * (X + C);}else {CO -= RR;}}break;case WU.WK:float RY = CO / QR;if (RY > 0.6f){QF = 1;v(RR);}else if( RY > 0.3f){QF = 2;CO -= RR;}else {QF = 3;CO -= RR;}break;default:v(RR);break;}CQ = WW.WR;EB();}void c(){QD = !QD;}public IEnumerator RU(float RI){c();yield return new WaitForSeconds(RI);c();}public void RO(float RP){if(CA != WU.WG) SC(RU(RP));}public void RA(float RS){SC(RU(RS));}void v( float RD ){if (CW == false){CO -= RD * X;s.RF();CY.RG(ItemType.NinjaPoints, 1);}else {CO -= RD;}}public void RH(Vector3 pos){EE(false);CQ = WW.WY;o = pos;EQ(o);}public void EA(){GameObject RK = Instantiate(CT, new Vector3(transform.position.x,transform.position.y + CU,transform.position.z), Quaternion.identity);RK.transform.parent = transform;}public void ER(){if (!QG){GameObject A = Instantiate(CR, new Vector3(transform.position.x, transform.position.y + CU, transform.position.z), Quaternion.identity);A.transform.parent = transform;QG = true;}}public void RJ(){transform.position = QI;i = false;CQ = WW.WE;CW = false;QP = CK;ER();}void Start(){q = FOT<Pathfinder_SebastianMol>();QU = transform.localScale.x;w = transform.position;QI = transform.position;e = CF.Length-1;r = CH;if (CF.Length > 0) t = CF[0];u = m;QR = CO;QP = CK;QS = V;CY = F("Player").GetComponent<Inventory_JoaoBeijinho>();QH = FOT<PlayerStealth_JoaoBeijinho>();s = Camera.main.GetComponent<CameraShakeElliott>();}void Update(){if(!QD){z();EK();RQ();}}void OnTriggerEnter2D(Collider2D RL){if(!QD)if(!CW){EY(RL.gameObject);}}void OnTriggerStay2D(Collider2D RZ){if (!QD)if (!CW){EY(RZ.gameObject);}}}