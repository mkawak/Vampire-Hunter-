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
        SettingMenu.SetActive(true);
        PauseGame();
    }

    public void CloseSettingMenu()
    {
        SettingMenu.SetActive(false);
        ResumeGame();
    }

    public void OpenOptions()
    {
        Options.SetActive(true);
        PauseGame();
    }

    public void CloseOptions()
    {
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


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
