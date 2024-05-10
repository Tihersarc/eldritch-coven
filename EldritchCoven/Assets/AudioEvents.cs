using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter rainEmitter;
    [SerializeField] private StudioEventEmitter ambienceEmitter;

    [SerializeField] [Range(0f,1f)] private float rainVolumeInside = .1f;

    public void InsideHouse()
    {
        ambienceEmitter.Play();
        rainEmitter.SetParameter("RainLoudness", rainVolumeInside);
    }
}
