using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPBAR : MonoBehaviour
{
    public int level;
    public float experience { get; private set; }
    public TMP_Text playerLevel;
    public Slider slider;
    public GameObject showUpgradeItemMenu;

    public void Start()
    {
        experience = 0;
        level = 1;
        slider.value = experience; 
        DisplayLevel();
        showUpgradeItemMenu.SetActive(false);
    }

    public void Update()
    {
        DisplayLevel();
    }

    public int EXPNeedToLevelUp(int currentLevel)
    {
        if (currentLevel == 0)
        {
            return 0;
        }
        return currentLevel * currentLevel + currentLevel;
    }

    public void AddEXP(int amount)
    {
        slider.value += amount;
        //float expNeeded = EXPNeedToLevelUp(level);
        /*        
                float previousExperience = EXPNeedToLevelUp(level - 1);*/

        if (slider.value >= 100)
        {
            showUpgradeItemMenu.SetActive(true);
            LevelUp();
/*          expNeeded = EXPNeedToLevelUp(level);
            previousExperience = EXPNeedToLevelUp(level - 1);*/
        }
    }

    public void DisplayLevel()
    {
        playerLevel.text = string.Format("LV. " + level);
    }

    public void LevelUp()
    {
        level++;
        slider.value = 0;
        showUpgradeItemMenu.SetActive(false);
    }

/*    public void UpgradeItemMenu()
    {
        

    } 
*/

}
