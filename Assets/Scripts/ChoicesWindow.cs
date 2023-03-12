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

    List<int> optionWeapon = new List<int>(new int[3]);
    List<int> optionType = new List<int>(new int[3]); // 0 is new, 1 is upgrade;
    void OnEnable() {
        RollOptions();
        DisplayOptions();
        RelayOptions();
    }

    void RollOptions() {
        int tot = gm.weaponList.Count + gm.playerWeapons_upgradeable.Count;
        // Need to check if tot is < 3;

        for (int i = 0; i < 3; i++) {
            int ind = Random.Range(0, tot);
            for (int j = 0; j < i; j++) {
                if (ind == optionWeapon[j]) {
                    ind = (ind + 1 >= tot) ? 0 : ind + 1;
                }
            }

            optionType[i] = (ind >= gm.weaponList.Count) ? 1 : 0;
            optionWeapon[i] = (ind >= gm.weaponList.Count) ? ind - gm.weaponList.Count : ind;
        }
    }

    // TextMeshProUGUI
    void DisplayOptions() {
        for(int i = 0; i < 3; i++) {
            TextMeshProUGUI currText = selections[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            currText.text = optionWeapon[i].ToString();
            currText = selections[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            currText.text = (optionType[i] == 0) ? "Add" : "Upgrade";
        }
    }

    void RelayOptions() {
        wl.optionWeapon = optionWeapon;
        wl.optionType = optionType;
    }
}
