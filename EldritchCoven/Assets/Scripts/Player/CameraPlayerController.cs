using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CameraPlayerController : MonoBehaviour
{
    public static Action<Quaternion> onRotateCamera;
    public static Action onMoveCamera;
    private Camera playerCamera;
    [SerializeField] private float sensitivity = 2.0f;
    [SerializeField] private float rotLimit = 45.0f;
    [SerializeField] private InputActionAsset playerControls;
    private float rotationX = 0.0f;

    Rigidbody rb;

    Camera mainCamera;
    float mouseY;
    float mouseX;
    private Vector2 lookInput;
    private InputAction lookAction;

    void Start()
    {
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();

        lookAction = playerControls.FindActionMap("Player").FindAction("Look");

        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        //lookAction.Enable();
    }
    private void Update()
    {
        if (PauseBehaviour.Instance.IsPaused)
        {
            return;
        }

        MoveCamera();
    }

    private void MoveCamera()
    {
        //mouse movement per frame
        mouseX = lookInput.x * sensitivity;
        mouseY -= lookInput.y * sensitivity;

        //// X-axis rotation (vertical) with limits
        //rotationX -= mouseY;
        //rotationX = Mathf.Clamp(rotationX, -rotLimit, rotLimit);

        ////camera rotation
        //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        //Quaternion rotation = Quaternion.Euler(0, mouseX * sensitivity, 0);
        //rb.MoveRotation(rb.rotation * rotation);

        transform.Rotate(0, mouseX, 0);

        mouseY = Mathf.Clamp(mouseY, -rotLimit, rotLimit);
        //transform.Rotate(0, 0, 0);
        mainCamera.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);

    }
}
