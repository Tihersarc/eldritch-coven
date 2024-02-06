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

    private StairBehaviuor sb;
    private Vector2 moveInput;
    private MovementBehaviour mvb;
    [SerializeField] private GameObject plane;
    [SerializeField] private Camera camera;

    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();
        sb = GetComponent<StairBehaviuor>();
    }

    private void FixedUpdate()
    {
        Debug.Log(moveInput);
        if (moveInput != Vector2.zero)
        {
            mvb.MoveRB(moveInput);
            sb.StepClimb();
        }
        else
        {
            mvb.StopRB();
        }
    }

    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    void OnTakePhoto(InputValue input)
    {
        showHiddenObjects?.Invoke();
        plane.GetComponent<PrintImage>().ConvertToImage(camera.targetTexture);
        hideObjects?.Invoke();
    }
}
