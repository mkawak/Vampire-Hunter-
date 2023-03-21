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
    private int currentWeaponLeve;

    public GameObject upgradeWindow;

    PlayerCharacter player;

    public void Start()
    {   
        player = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();

        experience = 0;
        level = 1;
        slider.value = experience; 
        DisplayLevel();
        upgradeWindow.SetActive(false);
    }

    public void Update()
    {
        experience = player.GetExpAsPercentage();
        slider.value = experience;
        level = player.GetLevel();

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
            LevelUp();
            Time.timeScale = 0f;
            upgradeWindow.SetActive(true);
            //UpgradeWeaponWindow();

            /*            expNeeded = EXPNeedToLevelUp(level);
                        previousExperience = EXPNeedToLevelUp(level - 1);*/
        }
    }

    public void DisplayLevel()
    {
        playerLevel.text = string.Format("LV. " + level);
    }

    public void LevelUp()
    {
        Time.timeScale = 0f;
        upgradeWindow.SetActive(true);
        //ChangeStats();
    }


/*    public void UpgradeWeaponWindow()
    {
        
       *//*  After weapon function done, put them here*//*
         
        CloseUpgradeWeaponWindow();
    }*/


    public void CloseUpgradeWeaponWindow()
    {
        upgradeWindow.SetActive(false);
        Time.timeScale = 1f;
    }
}