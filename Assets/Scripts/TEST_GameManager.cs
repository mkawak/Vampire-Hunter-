using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_GameManager : MonoBehaviour
{
    public GameObject player;

    public List<Weapon> weaponList;
    public List<Weapon> playerWeapons;
    public List<Weapon> playerWeapons_upgradeable;

    public List<Item> itemList;
    public List<Item> playerItems;
    public List<Item> playerItems_upgradeable;

    public List<Weapon> comboFabs = new List<Weapon>();

    Dictionary<string, string> combos = new Dictionary<string, string>() {{"shooty", "ray"}, {"ray", "shooty"}, {"lightningBall", "aura"}, {"aura", "lightningBall"}};
    Dictionary<string, int> comboMaxed = new Dictionary<string, int>() {{"shooty", 0}, {"ray", 0}, {"lightningBall", 0}, {"aura", 0}};
    Dictionary<string, Weapon> comboWeapon;

    void Start() {
        comboWeapon = new Dictionary<string, Weapon>(){{"shooty", comboFabs[0]}, {"ray", comboFabs[0]}, {"lightningBall", comboFabs[1]}, {"aura", comboFabs[1]}};
    }

    void ComboWeapons(int ind) {
        string otherWeaponName = combos[playerWeapons_upgradeable[ind].name];
        int weap1 = -1, weap2 = -1;
        for (int i = 0; i < playerWeapons.Count; i++) {
            if (weap1 == -1 && (playerWeapons[i].name == otherWeaponName || playerWeapons[i].name == playerWeapons_upgradeable[ind].name)) weap1 = i;
            else if (weap2== -1 && (playerWeapons[i].name == otherWeaponName || playerWeapons[i].name == playerWeapons_upgradeable[ind].name)) {weap2 = i; break;}
        }

        Destroy(playerWeapons[weap1].gameObject);
        Destroy(playerWeapons[weap2].gameObject);

        playerWeapons.RemoveAt(weap2);
        playerWeapons.RemoveAt(weap1);
        playerWeapons_upgradeable.RemoveAt(ind);
        

        Weapon currWeapon = Instantiate(comboWeapon[otherWeaponName], Vector3.zero, Quaternion.identity);
        currWeapon.transform.parent = player.transform;
        currWeapon.transform.localPosition = Vector3.zero;
        playerWeapons.Add(currWeapon);
    }

    public void UpgradeWeapon(int ind) {
        if (playerWeapons_upgradeable[ind].GetLevel() == 3) {
            ComboWeapons(ind);
            return;
        }

        playerWeapons_upgradeable[ind].LevelUp();
        if (playerWeapons_upgradeable[ind].GetLevel() == 3){

            if (combos.ContainsKey(playerWeapons_upgradeable[ind].name)) {
                comboMaxed[playerWeapons_upgradeable[ind].name] = 1;
                if (comboMaxed[combos[playerWeapons_upgradeable[ind].name]] == 1) {
                    return;
                }
            }
            playerWeapons_upgradeable.RemoveAt(ind);
        }
    }

    public void AddWeapon(int ind) {
        Weapon currWeapon = Instantiate(weaponList[ind], Vector3.zero, Quaternion.identity);
        currWeapon.transform.parent = player.transform;
        currWeapon.transform.localPosition = Vector3.zero;
        playerWeapons.Add(currWeapon);
        playerWeapons_upgradeable.Add(currWeapon);
        weaponList.RemoveAt(ind);
    }

    public void UpgradeItem(int ind) {
        playerItems_upgradeable[ind].LevelUp();
        if (playerItems_upgradeable[ind].GetLevel() == 3) playerItems_upgradeable.RemoveAt(ind);
    }

    public void AddItem(int ind) {
        Item currItem= Instantiate(itemList[ind], Vector3.zero, Quaternion.identity);
        currItem.transform.parent = player.transform;
        currItem.transform.localPosition = Vector3.zero;
        playerItems.Add(currItem);
        playerItems_upgradeable.Add(currItem);
        itemList.RemoveAt(ind);
    }

    public EXPBAR xpbar;
    public void LeveledUp() {
        xpbar.AddEXP(100);
    }
}
