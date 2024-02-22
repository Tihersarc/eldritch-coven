using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour
{

    [Range(0.0f, 1.0f)]
    public float slider;

    [SerializeField] private Animation animationComponent;
    [SerializeField] private AnimationClip animationClip;

    void Start()
    {

        animationComponent.enabled = true;
        animationClip = animationComponent.clip;
        animationComponent[animationClip.name].weight = 1;
        animationComponent.Play();
        animationComponent[animationClip.name].speed = 0;
    }

    void Update()
    {
        animationComponent.clip.legacy = true;
        animationComponent[animationClip.name].normalizedTime = slider;
    }
}


