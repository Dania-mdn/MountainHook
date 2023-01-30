using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Optiuns : MonoBehaviour
{
    private void Awake()
    {
        MobileAds.Initialize(InitStatus => { });
    }
    bool music = false;
    bool sound = false;
    public AudioMixerGroup mixer;
    public Toggle Music;
    public Toggle Sound;
    void Start()
    {
        if (PlayerPrefs.HasKey("musika"))
        {
            if (PlayerPrefs.GetInt("musika") == 0)
            {
                Music.isOn = false;
                mixer.audioMixer.SetFloat("musika", 0);
                music = false;
            }
            else
            {
                Music.isOn = true;
                mixer.audioMixer.SetFloat("musika", -80);
                music = true;
            }
        }
        else
        {
            if(Music.isOn == true)
            {
                mixer.audioMixer.SetFloat("musika", -80);
            }
            else
            {
                mixer.audioMixer.SetFloat("musika", 0);
            }
        }
        if (PlayerPrefs.HasKey("zwuki"))
        {
            if (PlayerPrefs.GetInt("zwuki") == 0)
            {
                Sound.isOn = false;
                mixer.audioMixer.SetFloat("zwuki", 0);
                sound = false;
            }
            else
            {
                Sound.isOn = true;
                mixer.audioMixer.SetFloat("zwuki", -80);
                sound = true;
            }
        }
        else
        {
            if (Sound.isOn == true)
            {
                mixer.audioMixer.SetFloat("zwuki", -80);
            }
            else
            {
                mixer.audioMixer.SetFloat("zwuki", 0);
            }
        }
    }
    public void music_off()
    {
        if (music)
        {
            mixer.audioMixer.SetFloat("musika", 0);
            music = false;
            PlayerPrefs.SetInt("musika", 0);
        }
        else
        {
            mixer.audioMixer.SetFloat("musika", -80);
            music = true;
            PlayerPrefs.SetInt("musika", -80);
        }
    }
    public void sounf_off()
    {
        if (sound)
        {
            mixer.audioMixer.SetFloat("zwuki", 0);
            sound = false;
            PlayerPrefs.SetInt("zwuki", 0);
        }
        else
        {
            mixer.audioMixer.SetFloat("zwuki", -80);
            sound = true;
            PlayerPrefs.SetInt("zwuki", -80);
        }
    }
    public void instagramm()
    {
        Application.OpenURL("https://www.instagram.com/gamesdmurdok/?hl=ru");
    }
}
