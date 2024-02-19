using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Polaroid : MonoBehaviour
{
    private Animator anim;
    private bool usingCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    public void OnAimCamera(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (usingCamera)
            {
                anim.speed = -1;
                usingCamera = false;
            }
            else
            {
                anim.speed = 1;
                usingCamera = true;
            }
        }
    }
}
