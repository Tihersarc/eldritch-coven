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

    private Vector2 lookInput;
    private InputAction lookAction;

    void Start()
    {
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();

        lookAction  = playerControls.FindActionMap("Player").FindAction("Look");
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
        //float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;
        Debug.Log("X:" + lookInput.x + "\nY: " + mouseY);

        // X-axis rotation (vertical) with limits
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -rotLimit, rotLimit);

        //camera rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        
        //transform.Rotate(Vector3.up * mouseX);
        Quaternion rotation = Quaternion.Euler(0, mouseX * sensitivity, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }
}
