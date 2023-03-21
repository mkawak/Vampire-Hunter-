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

    public List<int> optionChoice = new List<int>(new int[3]);
    public List<int> optionType = new List<int>(new int[3]); // 0 is new weapon, 1 is upgrade weapon, 2 is new item, 3 is upgrade weapon;
    public void OnEnable() {
        RollOptions();
        DisplayOptions();
        RelayOptions();
    }

    public int tot = 3;
    public void RollOptions() {
        List<int> nums = new List<int>{gm.weaponList.Count, gm.playerWeapons_upgradeable.Count, gm.itemList.Count, gm.playerItems_upgradeable.Count};
        List<int> counts = new List<int>{gm.weaponList.Count, gm.playerWeapons_upgradeable.Count, gm.itemList.Count, gm.playerItems_upgradeable.Count};
        
        int currTot = 0;
        for (int i = 0; i < counts.Count; i++) currTot += counts[i];
        if (currTot < 3) tot = currTot;

        for (int i = 0; i < tot; i++) {

            int type = Random.Range(0, 4);

            for (int iter = 0; iter < 6; iter++) { // Probably the worst way to do this
                if (counts[type] != 0) {
                    break;
                }
                type = (type == 3) ? 0 : type + 1;
                if (iter == 6) Debug.Log("A");
            }

            int ind = Random.Range(0, nums[type]);
            for (int aa = 0; aa < 2; aa++) {
                for (int bb = 0; bb < i; bb++) {
                    if (optionType[bb] == type && optionChoice[bb] == ind) {
                        ind = (ind + 1 >= nums[type]) ? 0 : ind + 1;
                    }
                }
            }

            counts[type]--;   

            optionType[i] = type;
            optionChoice[i] = ind;
        }
    }

    // TextMeshProUGUI
    public void DisplayOptions() {
        for (int i = 0; i < tot; i++) {
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
        for (int i = tot; i < 3; i++) {
            selections[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "EMPTY";
            selections[i].transform.GetChild(3).GetComponent<Image>().sprite = null;
        }
    }

    public void RelayOptions() {
        wl.optionWeapon = optionChoice;
        wl.optionType = optionType;
    }
}
