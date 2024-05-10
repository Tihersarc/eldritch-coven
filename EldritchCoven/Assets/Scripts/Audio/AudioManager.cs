using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    const string VCAPath = "vca:/";
    const string generalVCAPath = "General";
    const string musicVCAPath = "Music";
    const string SFXVCAPath = "SFX";

    public static AudioManager Instance { get; private set; }

    private VCA generalVCA;
    private VCA sfxVCA;
    private VCA musicVCA;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;


    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        generalVCA = FMODUnity.RuntimeManager.GetVCA(VCAPath + generalVCAPath);
        sfxVCA = FMODUnity.RuntimeManager.GetVCA(VCAPath + SFXVCAPath);
        musicVCA = FMODUnity.RuntimeManager.GetVCA(VCAPath + musicVCAPath);

        var master = PlayerPrefs.GetFloat("Master Volume" + "DarkSliderValue");
        var sfx = PlayerPrefs.GetFloat("SFX Volume" + "DarkSliderValue");
        var music = PlayerPrefs.GetFloat("Music Volume" + "DarkSliderValue");

        generalVCA.setVolume(master);
        sfxVCA.setVolume(sfx);
        musicVCA.setVolume(music);

        if (masterSlider)
            musicSlider.value = master;

        if (sfxSlider)
            sfxSlider.value = sfx;

        if (musicSlider)
            musicSlider.value = music;
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
