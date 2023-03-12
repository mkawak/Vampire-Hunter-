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

    void Start() {

    }

    public void UpgradeWeapon(int ind) {
        playerWeapons_upgradeable[ind].LevelUp();
        if (playerWeapons_upgradeable[ind].GetLevel() == 3) playerWeapons_upgradeable.RemoveAt(ind);
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
