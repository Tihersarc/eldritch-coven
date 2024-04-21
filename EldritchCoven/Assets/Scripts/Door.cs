using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;
    public void Interact()
    {
        if (!opened)
            GetComponent<Animator>().SetTrigger("open");
        else
            GetComponent<Animator>().SetTrigger("close");

        opened = !opened;
    }
}
