using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    Transform playerCameraTransform;
    [SerializeField] Transform mirror;

    void Start()
    {
        playerCameraTransform = Camera.main.transform;
        CameraPlayerController.onRotateCamera += RotateCamera;
    }

    void Update()
    {
        Vector3 mirrorPosition = playerCameraTransform.position - 2 * Vector3.Dot(playerCameraTransform.position - mirror.position, mirror.forward) * mirror.forward;
        transform.position = mirrorPosition;
    }

    void RotateCamera(Quaternion rotation)
    {
        transform.localRotation = rotation;
    }
}
