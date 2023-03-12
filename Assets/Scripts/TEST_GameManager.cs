using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_GameManager : MonoBehaviour
{
    public GameObject player;

    public List<Weapon> weaponList;
    public List<Weapon> playerWeapons;
    public List<Weapon> playerWeapons_upgradeable;

    void Start() {

    }

    public void UpgradeWeapon(int ind) {
        playerWeapons_upgradeable[ind].LevelUp();
        if (playerWeapons_upgradeable[ind].GetLevel() == 3) playerWeapons_upgradeable.RemoveAt(ind);
    }

    public void AddWeapon(int ind) {
        // Debug.Log("Add");
        // Debug.Log(ind);
    }

}
