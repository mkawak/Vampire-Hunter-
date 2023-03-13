using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public TEST_GameManager gm;

    public List<int> optionWeapon = new List<int>(new int[3]);
    public List<int> optionType = new List<int>(new int[3]);

    public void ChooseOption(int choice) {
        switch(optionType[choice]) {
            case 0: 
                gm.AddWeapon(optionWeapon[choice]);
                break;
            case 1:
                gm.UpgradeWeapon(optionWeapon[choice]);
                break;
            case 2:
                gm.AddItem(optionWeapon[choice]);
                break;
            case 3:
                gm.UpgradeItem(optionWeapon[choice]);
                break;
        }
        

        gameObject.GetComponent<EXPBAR>().CloseUpgradeWeaponWindow();
    }
}
