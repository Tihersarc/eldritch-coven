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

    private MovementBehaviour mvb;
    private StairBehaviuor stairBehaviour;
    private StepsPlayer stepsPlayer;
    
    private Vector2 moveInput;
    [SerializeField] private GameObject plane;
    [SerializeField] private Camera cameraPhotos;



    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();
        stairBehaviour = GetComponent<StairBehaviuor>();
        stepsPlayer = GetComponentInChildren<StepsPlayer>();
    }

    private void Update()
    {
        //stepsPlayer.MaterialCheck();
        //GetComponentInChildren<StepsPlayer>().MaterialCheck();
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            mvb.MoveRB(moveInput);
            stairBehaviour.StepClimb();
            //stepsPlayer.MaterialCheck(); // TODO Check why sound breaks
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
        plane.GetComponent<PrintImage>().ConvertToImage(cameraPhotos.targetTexture);
        hideObjects?.Invoke();
    }
}
