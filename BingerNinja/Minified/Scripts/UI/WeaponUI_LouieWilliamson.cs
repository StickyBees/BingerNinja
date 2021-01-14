using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;public class WeaponUI_LouieWilliamson : M{public Text weaponText;public Image weaponImage;public Text rangedText;public Image rangedImage;public Text ammoText;public Image pickupImage;Animator a;public Animator pickupAnim;public Animator keyAnim;public GameObject MeleeHighlight;public GameObject RangedHighlight;public List<Sprite> WeaponSprites = new List<Sprite>();int s;public Texture2D rangedCursor;public Texture2D normalCursor;Vector2 d;Vector2 f;public void SetActiveWeapon(bool m){MeleeHighlight.SetActive(m);RangedHighlight.SetActive(!m);SetCursor(!m);}public void SetWeaponsUIAnimation(bool n){a.SetBool("isOnScreen", n);}public void setKey(bool b){keyAnim.SetBool("hasKey", b);}public void setPickupAnim(bool v){pickupAnim.SetBool("isPickupShown", v);}public void setPickupImage(FoodType c){pickupImage.sprite = WeaponSprites[(int)c];}public void removeWeapon(bool x){if (x){rangedImage.sprite = WeaponSprites[8];setAmmo(-50);}else {weaponImage.sprite = WeaponSprites[8];}setName("None", x);}public void WeaponChange(FoodType z, bool a, int s){if (a){setAmmo(s);}setName(z.ToString(), a);setImage((int)z, a);}public void setAmmo(int g){s = g;if (s < 0) s = 0;ammoText.text = s.ToString();}void Start(){a = GetComponent<Animator>();removeWeapon(true);removeWeapon(false);d = new Vector2(4, 0);f = new Vector2( 8, 8);}void setName(string h, bool j){if (j){rangedText.text = h;}else {weaponText.text = h;}}void setImage(int y, bool t){if (t){rangedImage.sprite = WeaponSprites[y];}else {weaponImage.sprite = WeaponSprites[y];}}void SetCursor(bool e){if (e){Cursor.SetCursor(rangedCursor, f, CursorMode.Auto);}else {Cursor.SetCursor(normalCursor, d, CursorMode.Auto);}}}