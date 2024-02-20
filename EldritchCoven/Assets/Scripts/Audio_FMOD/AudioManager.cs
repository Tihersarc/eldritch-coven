using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    const string VCAPath = "vca:/";
    const string generalVCAPath = "General";
    const string musicVCAPath = "Music";
    const string SFXVCAPath = "SFX";

    public static AudioManager Instance { get; private set; }

    VCA generalVCA;
    VCA sfxVCA;
    VCA musicVCA;


    public void Start()
    {
        generalVCA = FMODUnity.RuntimeManager.GetVCA(VCAPath + generalVCAPath);
        sfxVCA = FMODUnity.RuntimeManager.GetVCA(VCAPath + musicVCAPath);
        musicVCA = FMODUnity.RuntimeManager.GetVCA(VCAPath + SFXVCAPath);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        generalVCA.setVolume(volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxVCA.setVolume(volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVCA.setVolume(volume);
    }
}
