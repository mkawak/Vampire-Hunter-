using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider musicSilder, sfxSlider;
    
    void Start()
    {

        /*        AudioManager.Instance.MusicVolume(musicSilder.value);
                AudioManager.Instance.SFXVolume(sfxSlider.value);*/
        //musicSilder.value = PlayerPrefs.GetFloat("volume");
        
    }

    void update()
    {
        /*        AudioManager.Instance.MusicVolume(musicSilder.value);
                AudioManager.Instance.SFXVolume(sfxSlider.value);*/
        /*        musicSilder.value = PlayerPrefs.GetFloat("volume");
                sfxSlider.value = PlayerPrefs.GetFloat("volume2");
                PlayerPrefs.SetFloat("volume", musicSilder.value);
                PlayerPrefs.SetFloat("volume2", sfxSlider.value);*/

        //AudioManager.Instance.MusicVolume(PlayerPrefs.SetFloat("volume"));
    }

    public void MusicVolume()
    {
        /*musicSilder.value = PlayerPrefs.GetFloat("volume");
        PlayerPrefs.SetFloat("volume", musicSilder.value);*/
        AudioManager.Instance.MusicVolume(musicSilder.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
    }

}
