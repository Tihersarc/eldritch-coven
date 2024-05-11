using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Photo : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject image;
    private PrintImage printImage;
    private RevealImage revealImage;

    void Start()
    {
        anim = GetComponent<Animator>();
        printImage = image.GetComponent<PrintImage>();
        revealImage = image.GetComponent<RevealImage>();
    }

    public void ShowImage()
    {
        printImage.ApplyTexture();
    }

    public void HideImage()
    {
        revealImage.TakePhoto();
    }

    public void TakePhoto()
    {
        anim.SetTrigger("HasTakenPhoto");
    }

    public void Reveal(bool performed)
    {
        if (performed)
        {
            anim.SetBool("Revealing", true);
        }

        if (!performed)
        {
            anim.SetBool("Revealing", false);
        }
    }

    public void CallRevealImage()
    {
        revealImage.StartRevealing();
    }
}
