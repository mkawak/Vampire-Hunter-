using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject Options;
    public GameObject CharacterMenu;
    public GameObject MapMenu;

    void Start()
    {
        StartMenu.SetActive(true);
        Options.SetActive(false);
        CharacterMenu.SetActive(false);
        MapMenu.SetActive(false);
    }

    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenStartMenu()
    {
        StartMenu.SetActive(true);
    }

    public void CloseStartMenu()
    {
        StartMenu.SetActive(false);
    }

    public void OpenCharacterMenu()
    {
        CharacterMenu.SetActive(true);
    }

    public void CloseCharacterMenu()
    {
        CharacterMenu.SetActive(false);
    }

    public void OpenSettingMenu()
    {
        Options.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        Options.SetActive(false);
    }

    public void OpenMapMenu()
    {
        MapMenu.SetActive(true);
    }

    public void CloseMapMenu()
    {
        MapMenu.SetActive(false);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}