using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Animation anim;

    public void Interact()
    {
        Debug.Log("lol");
        anim.Play();
    }
}
