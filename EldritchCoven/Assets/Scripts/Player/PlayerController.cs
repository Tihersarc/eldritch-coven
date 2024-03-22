using FMODUnity;
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

    [SerializeField]
    private LayerMask interactableLayers;
    [SerializeField]
    private float interactableDistance;

    private Vector2 moveInput;
    [SerializeField] private GameObject plane;
    [SerializeField] private Camera cameraPhotos;
    [SerializeField] private StudioEventEmitter cameraSoundEmitter;


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

    void OnMove(InputValue input)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            moveInput = input.Get<Vector2>();
        }
    }

    void OnTakePhoto(InputValue input)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            showHiddenObjects?.Invoke();
            cameraPhotos.Render();
            plane.GetComponent<PrintImage>().ConvertToImage(cameraPhotos.targetTexture);
            hideObjects?.Invoke();
            cameraSoundEmitter.Play();
        }
    }

    void OnPause(InputValue input)
    {
        PauseBehaviour.Instance.TogglePause();
    }

    void OnInteract(InputValue input)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            RaycastHit hit;
            Button button;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactableDistance, interactableLayers))
            {
                if (hit.transform.TryGetComponent<Button>(out button))
                {
                    button.Interact();
                }
            }
            
        }
    }
}