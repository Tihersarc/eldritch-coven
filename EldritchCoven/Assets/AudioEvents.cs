using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter rainEmitter;
    [SerializeField] private StudioEventEmitter ambienceEmitter;

    public void InsideHouse()
    {
        ambienceEmitter.Play();
        rainEmitter.SetParameter("RainLoudness", 0);
    }
}
