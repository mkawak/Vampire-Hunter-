using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public void GoToScene(string sceneName1) {
        SceneManager.LoadScene(sceneName1);
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("volume",  volume);
    }
}
