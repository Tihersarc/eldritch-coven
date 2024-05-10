using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.DefaultInputActions;

public class PlayerController : MonoBehaviour
{
    public delegate void ShowHiddenObjects();
    public static event ShowHiddenObjects showHiddenObjects;

    public delegate void HideObjects();
    public static event HideObjects hideObjects;

    private MovementBehaviour mvb;
    private StairBehaviour stairBehaviour;
    //private StepsPlayer stepsPlayer;

    [SerializeField]
    private LayerMask interactableLayers;
    [SerializeField]
    private float interactableDistance;

    private Vector2 moveInput;
    [SerializeField] private GameObject plane;
    [SerializeField] private Camera cameraPhotos;
    [SerializeField] private StudioEventEmitter cameraSoundEmitter;
    [SerializeField] private Photo photo;
    [SerializeField] private Polaroid polaroid;
    [SerializeField] private RevealImage Image;


    private PlayerInput playerInput;

    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();
        stairBehaviour = GetComponent<StairBehaviour>();
        playerInput = GetComponent<PlayerInput>();

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
        playerInput.actions.FindActionMap("Player").Enable();
        playerInput.actions.FindActionMap("Pause").Enable();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            moveInput = ctx.ReadValue<Vector2>();
            Debug.Log(moveInput);
        }
    }

    public void OnTakePhoto(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            showHiddenObjects?.Invoke();
            cameraPhotos.Render();
            plane.GetComponent<PrintImage>().ConvertToImage(cameraPhotos.targetTexture);
            hideObjects?.Invoke();
            cameraSoundEmitter.Play();

            if (ctx.performed)
            {
                photo.TakePhoto();
                Image.TakePhoto();
            }
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        PauseBehaviour.Instance.TogglePause();
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            Debug.Log("O_O");
            RaycastHit hit;
            Button button;
            Door door;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactableDistance, interactableLayers))
            {
                if (hit.transform.TryGetComponent<Button>(out button))
                {
                    button.Interact();
                }

                if (hit.transform.TryGetComponent<Door>(out door))
                {
                    door.Interact();
                }
            }

        }
    }

    public void OnReveal(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            if (ctx.performed)
            {
                photo.Reveal(true);
                Image.Reveal(true);
            }
            if (ctx.canceled)
            {
                photo.Reveal(!true);
                Image.Reveal(!true);
            }
        }
    }

    public void OnAimCamera(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            if (ctx.performed)
            {
                polaroid.AimCamera();
            }
        }
    }














}