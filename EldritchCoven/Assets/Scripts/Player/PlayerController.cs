using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
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

    private Vector2 moveInput = Vector2.zero;
    [SerializeField] private GameObject plane;
    [SerializeField] private Camera cameraPhotos;
    [SerializeField] private StudioEventEmitter cameraSoundEmitter;
    [SerializeField] private Photo photo;
    [SerializeField] private Polaroid polaroid;
    [SerializeField] private RevealImage Image;

    private GameObject detectedInteractableObject = null;

    private PlayerInput playerInput;

    private void Start()
    {
        mvb = GetComponent<MovementBehaviour>();
        stairBehaviour = GetComponent<StairBehaviour>();
        playerInput = GetComponent<PlayerInput>();
        DisablePlayerActionMap();
        //EnableActionMaps();

        //stepsPlayer = GetComponentInChildren<StepsPlayer>();
    }

    private void Update()
    {
        //stepsPlayer.MaterialCheck();
        //GetComponentInChildren<StepsPlayer>().MaterialCheck();

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactableDistance, interactableLayers))
        {
            Outline outline; hit.transform.gameObject.TryGetComponent<Outline>(out outline);

            if ((detectedInteractableObject != hit.transform.gameObject) && outline != null)
            {
                detectedInteractableObject = hit.transform.gameObject;
                outline.OutlineWidth = 10;
                StartCoroutine(_CheckInteractableOutOfDistance(detectedInteractableObject));
            }
        }
        else
        {
            detectedInteractableObject = null;
        }
    }

    IEnumerator _CheckInteractableOutOfDistance(GameObject interactableObject)
    {
        RaycastHit hit;
        while (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactableDistance, interactableLayers))
        {
            if (hit.transform.gameObject != interactableObject)
                break;
            yield return null;
        }
        
        interactableObject.GetComponent<Outline>().OutlineWidth = 0;
        detectedInteractableObject = null;
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
            //transform.position = transform.position;
        }
    }

    private void EnableActionMaps()
    {
        playerInput.actions.FindActionMap("Player").Enable();
        playerInput.actions.FindActionMap("Pause").Enable();
    }

    public void DisablePlayerActionMap()
    {
        playerInput.actions.FindActionMap("Player").Disable();
        playerInput.actions.FindActionMap("Pause").Disable();
    }

    public void EnablePlayerActionMap()
    {
        playerInput.actions.FindActionMap("Player").Enable();
        playerInput.actions.FindActionMap("Pause").Enable();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            moveInput = ctx.ReadValue<Vector2>();
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
            RaycastHit hit;
            Button button;
            Door door;
            Page page;
            Key key;
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
                if (hit.transform.TryGetComponent<Page>(out page))
                {
                    page.Interact();
                }
                if (hit.transform.TryGetComponent<Key>(out key))
                {
                    key.Interact();
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