using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public Slider musicSilder;
    public AudioMixer mixer;
    
    // Start is called before the first frame update
    void Start()
    {
        //musicSilder.value = 0.5f;
    }

    public void SetVolume()
    {
        mixer.SetFloat("Music", musicSilder.value);
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
}
