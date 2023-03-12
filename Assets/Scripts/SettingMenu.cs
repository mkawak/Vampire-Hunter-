using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider musicSilder, sfxSlider;
    

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSilder.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
    }

}
