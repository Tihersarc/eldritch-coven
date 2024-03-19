using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Polaroid : MonoBehaviour
{
    private bool usingCamera = false;
    [SerializeField]
    private AnimationTest anim;
    [SerializeField]
    private float animationTime = 0;
    [SerializeField]
    private float animationDuration = 0.3f;
    private bool playingAnimation = false;

    private void Start()
    {
        anim = GetComponent<AnimationTest>();
    }

    private void Update()
    {
        if (playingAnimation)
        {
            if (usingCamera)
            {
                animationTime += Time.deltaTime;
                if (animationTime >= animationDuration)
                {
                    animationTime = animationDuration;
                    playingAnimation = false;
                }
            }
            else
            {
                animationTime -= Time.deltaTime;
                if (animationTime <= 0)
                {
                    animationTime = 0;
                    playingAnimation = false;
                }
            }

            anim.slider = animationTime / animationDuration;
        }
    }

    public void OnAimCamera(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            if (ctx.performed)
            {
                if (usingCamera)
                {
                    usingCamera = false;
                }
                else
                {
                    usingCamera = true;
                }
                playingAnimation = true;
            }
        }
    }
}
