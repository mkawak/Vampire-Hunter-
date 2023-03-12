using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ChoicesWindow : MonoBehaviour
{
    public TEST_GameManager gm;

    public WeaponList wl;

    public List<GameObject> selections;

    List<int> optionChoice = new List<int>(new int[3]);
    List<int> optionType = new List<int>(new int[3]); // 0 is new weapon, 1 is upgrade weapon, 2 is new item, 3 is upgrade weapon;
    void OnEnable() {
        RollOptions();
        DisplayOptions();
        RelayOptions();
    }

    void RollOptions() {
        List<int> nums = new List<int>{gm.weaponList.Count, gm.playerWeapons_upgradeable.Count, gm.itemList.Count, gm.playerItems_upgradeable.Count};

        for (int i = 0; i < 3; i++) {

            int type = Random.Range(0, 4);

            for (int iter = 0; iter < 6; iter++) { // Probably the worst way to do this
                if (nums[type] != 0) {
                    nums[type]--;
                    break;
                }
                type = (type == 3) ? 0 : type + 1;
                if (iter == 6) Debug.Log("A");
            }

            int ind = Random.Range(0, nums[type]);
            for (int j = 0; j < i; j++) {
                if (type == optionType[j]) {
                    for (int aa = 0; aa < 2; aa++) {
                        for (int bb = 0; bb < i; bb++) {
                            if (optionType[bb] == type && optionChoice[bb] == ind) ind = (ind + 1 == nums[type]) ? 0 : ind + 1;
                        }
                    }
                }
            }

            optionType[i] = type;
            optionChoice[i] = ind;
        }
    }

    // TextMeshProUGUI
    void DisplayOptions() {
        for (int i = 0; i < 3; i++) {
            TextMeshProUGUI currText = selections[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            currText.text = (optionType[i] % 2 == 0) ? "New" : "Upgrade";

            Image weaponImage = selections[i].transform.GetChild(3).GetComponent<Image>();
            switch(optionType[i]) {
                case 0:
                    weaponImage.sprite = gm.weaponList[optionChoice[i]].image;
                    break;
                case 1:
                    weaponImage.sprite = gm.playerWeapons_upgradeable[optionChoice[i]].image;
                    if (gm.playerWeapons_upgradeable[optionChoice[i]].GetLevel() == 3) {
                        currText.text = "Combo";
                    }
                    break;
                case 2:
                    weaponImage.sprite = gm.itemList[optionChoice[i]].image;
                    break;
                case 3:
                    weaponImage.sprite = gm.playerItems_upgradeable[optionChoice[i]].image;
                    break;
            }
        }
    }

    void RelayOptions() {
        wl.optionWeapon = optionChoice;
        wl.optionType = optionType;
    }
}
