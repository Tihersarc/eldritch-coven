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

    public void OnReveal(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("OwO");
            anim.ResetTrigger("NewImage");
            anim.speed = 1;
        }
        if (ctx.canceled)
        {
            anim.speed = 0;
        }
    }

    public void TakePhoto()
    {
        anim.SetTrigger("NewImage");
    }
}
