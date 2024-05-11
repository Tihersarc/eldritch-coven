using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;
    [SerializeField] StudioEventEmitter doorSoundEmitter;

    private void Awake()
    {
        doorSoundEmitter = GetComponentInChildren<StudioEventEmitter>();
    }

    public void Interact()
    {
        doorSoundEmitter.Play();

        if (!opened)
            GetComponent<Animator>().SetTrigger("open");
        else
            GetComponent<Animator>().SetTrigger("close");

        opened = !opened;
        
    }
}
