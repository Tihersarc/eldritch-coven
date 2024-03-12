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
    private StairBehaviour stairBehaviour;
    //private StepsPlayer stepsPlayer;

    private Vector2 moveInput;
    [SerializeField] private GameObject plane;
    [SerializeField] private Camera cameraPhotos;

    private PlayerInput playerInput;
    private InputActionMap playerMap;


    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();
        stairBehaviour = GetComponent<StairBehaviour>();
        playerInput = GetComponent<PlayerInput>();

        playerMap = playerInput.actions.FindActionMap("Player");

        EnableActionMaps();

        //stepsPlayer = GetComponentInChildren<StepsPlayer>();
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

    private void EnableActionMaps()
    {
        playerMap.Enable();
        playerInput.actions.FindActionMap("Pause").Enable();
        Debug.Log("Maps activated");
    }

    void OnMove(InputValue input)
    {

        moveInput = input.Get<Vector2>();
    }

    void OnTakePhoto(InputValue input)
    {
        showHiddenObjects?.Invoke();
        cameraPhotos.Render();
        plane.GetComponent<PrintImage>().ConvertToImage(cameraPhotos.targetTexture);
        hideObjects?.Invoke();
    }

    void OnPause(InputValue input)
    {
        PauseBehaviour.Instance.TogglePause();
        if (PauseBehaviour.Instance.IsPaused)
        {
            playerMap.Disable();
        }
        else
        {
            //playerMap.Enable();
        }
    }
}