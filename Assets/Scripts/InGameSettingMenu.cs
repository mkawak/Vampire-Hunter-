using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSettingMenu : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject Options;

    // Start is called before the first frame update
    void Start()
    {
        SettingMenu.SetActive(false);
        Options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettingMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        SettingMenu.SetActive(true);
        PauseGame();
    }

    public void CloseSettingMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        SettingMenu.SetActive(false);
        ResumeGame();
    }

    public void OpenOptions()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");

        Options.SetActive(true);
        PauseGame();
    }

    public void CloseOptions()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");

        Options.SetActive(false);
        PauseGame();
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
/*
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSilder.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
    }*/


    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        Application.Quit();
        Debug.Log("Quit!");
    }
}
