using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Polaroid : MonoBehaviour
{
    private bool usingCamera = false;
    [SerializeField] private AnimationTest anim;
    [SerializeField] private float animationTime = 0;
    [SerializeField] private float animationDuration = 0.3f;
    [SerializeField] GameObject pointer;
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

    public void AimCamera()
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
                pointer.SetActive(!pointer.activeSelf);
    }
}
