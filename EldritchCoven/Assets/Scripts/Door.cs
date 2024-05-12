using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;
    [SerializeField] bool canOpen = true;
    public bool CanOpen { set { canOpen = value; }}

    [SerializeField] bool objectNeeded;
    [SerializeField] GameObject objectToOpen;
    [SerializeField] StudioEventEmitter doorSoundEmitter;

    private void Awake()
    {
        doorSoundEmitter = GetComponentInChildren<StudioEventEmitter>();
    }

    public void Interact()
    {
        if (objectNeeded)
        {
            if (GameLogic.instance.playerController.gameObject.GetComponent<Inventory>().objetctsInInventory.Contains(objectToOpen))
            {
                canOpen = true;
            }
            else
            {
                canOpen = false;
            }
        }

        if (canOpen) {
         
            doorSoundEmitter.Play();

            if (!opened)
                GetComponent<Animator>().SetTrigger("open");
            else
                GetComponent<Animator>().SetTrigger("close");

            opened = !opened;
        }
    }
}
