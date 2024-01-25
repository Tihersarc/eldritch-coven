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

    public void OnReveal(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            anim.ResetTrigger("NewImage");
            anim.Play("ImageFade");
            anim.speed = 1;
        }
        if (ctx.canceled)
        {
            //para de reveal the imagen
            anim.speed = 0;
        }
    }

    public void OnTakePhoto(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            anim.speed = 1;
            anim.SetTrigger("NewImage");
        }
    }
}
