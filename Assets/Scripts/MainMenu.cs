using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject Options;
    public GameObject CharacterMenu;

    void Start()
    {
        StartMenu.SetActive(true);
        Options.SetActive(false);
        CharacterMenu.SetActive(false);
    }

    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettingMenu()
    {
        Options.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        Options.SetActive(false);
    }

    public void OpenCharacterMenu()
    {
        CharacterMenu.SetActive(true);
    }

    public void CloseCharacterMenu()
    {
        CharacterMenu.SetActive(false);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}