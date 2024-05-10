using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RevealImage : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartRevealing()
    {
        anim.Play("ImageFade");
    }

    public void Reveal(bool performed)
    {
        if (performed)
        {
            anim.ResetTrigger("NewImage");
            anim.speed = 1;
        }
        if (!performed)
        {
            anim.speed = 0;
        }
    }

    public void TakePhoto()
    {
        anim.SetTrigger("NewImage");
    }
}
