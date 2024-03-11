using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public delegate void ShowHiddenObjects();
    public static event ShowHiddenObjects showHiddenObjects;

    public delegate void HideObjects();
    public static event HideObjects hideObjects;

    Vector2 moveInput;
    MovementBehaviour mvb;
    [SerializeField]
    GameObject plane;
    [SerializeField]
    Camera camera;

    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            mvb.MoveRB(moveInput);
        }
    }

    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    //void OnTakePhoto(InputValue input)
    //{
    //    showHiddenObjects?.Invoke();
    //    camera.Render();
    //    plane.GetComponent<PrintImage>().ConvertToImage(camera.targetTexture);
    //    hideObjects?.Invoke();
    //}
}
