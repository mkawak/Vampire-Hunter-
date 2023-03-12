using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public TEST_GameManager gm;

    public List<int> optionWeapon = new List<int>(new int[3]);
    public List<int> optionType = new List<int>(new int[3]);

    public void ChooseOption(int choice) { 
        if (optionType[choice] == 1) {
            gm.UpgradeWeapon(optionWeapon[choice]);
        }
        else {
            gm.AddWeapon(optionWeapon[choice]);
        }

        gameObject.GetComponent<EXPBAR>().CloseUpgradeWeaponWindow();
    }
}
