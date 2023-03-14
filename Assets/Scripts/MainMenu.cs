using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject Options;
    public GameObject CharacterMenu;
    public GameObject MapMenu;
    public GameObject CreditsPanel;

    void Start()
    {
        StartMenu.SetActive(true);
        Options.SetActive(false);
        CharacterMenu.SetActive(false);
        MapMenu.SetActive(false);
        CreditsPanel.SetActive(false);

        li = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();
    }

    void Update()
    {
/*        if(OpenStartMenu() || CloseStartMenu() || OpenCharacterMenu() || CloseCharacterMenu() || OpenSettingMenu() || OpenMapMenu() || CloseMapMenu())
        {*/
            //AudioManager.Instance.PlaySFX("PressButtonSFX");
       /* }*/
    }

    public void GoToScene(string sceneName) {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        SceneManager.LoadScene(sceneName);
    }
    

    public void OpenStartMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        StartMenu.SetActive(true);
    }

    public void CloseStartMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        StartMenu.SetActive(false);
    }

    public void OpenCreditsPanel()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        CreditsPanel.SetActive(true);
    }

    public void CloseCreditsPanel()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        CreditsPanel.SetActive(false);
    }

    public void OpenCharacterMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        CharacterMenu.SetActive(true);
    }

    public void CloseCharacterMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        CharacterMenu.SetActive(false);
    }

    public void OpenSettingMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        Options.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        Options.SetActive(false);
    }

    public void OpenMapMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");
        MapMenu.SetActive(true);
    }

    public void CloseMapMenu()
    {
        AudioManager.Instance.PlaySFX("PressButtonSFX");

        MapMenu.SetActive(false);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }


    public LevelInfo li;
    public void ChooseLevel(int i) {
        li.level = i;
    }

    public void ChoosePlayer(int i) {
        li.player = i;
    }
}