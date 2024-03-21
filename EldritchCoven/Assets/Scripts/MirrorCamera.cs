using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    Camera referenceCam;

    [SerializeField] 
    Transform mirror;

    [SerializeField]
    private float nearClipLimit = 0.2f;

    [SerializeField]
    private float nearClipOffset = 0.05f;

    void Start()
    {
        referenceCam = Camera.main;
    }

    void Update()
    {
        Vector3 cameraMirrorPosition = referenceCam.transform.position - 2 * Vector3.Dot(referenceCam.transform.position - mirror.position, mirror.forward) * mirror.forward;
        Vector3 mirrorForward = Vector3.Reflect(referenceCam.transform.forward, mirror.forward);
        this.transform.forward = mirrorForward;
        transform.position = cameraMirrorPosition;

        ChangeNearClipPlanes();
    }

    private void OnPreCull()
    {
        ChangeNearClipPlanes();
    }

    private void ChangeNearClipPlanes()
    {
        Transform clipPlane = this.transform.parent;
        int dot = System.Math.Sign(Vector3.Dot(clipPlane.forward, this.transform.parent.position - this.transform.position));

        Vector3 camSpacePos = this.GetComponent<Camera>().worldToCameraMatrix.MultiplyPoint(clipPlane.position);
        Vector3 camSpaceNormal = this.GetComponent<Camera>().worldToCameraMatrix.MultiplyVector(clipPlane.forward) * dot;
        float camSpaceDst = -Vector3.Dot(camSpacePos, camSpaceNormal) + nearClipOffset;

        // Impide usar oblique clip plane quando esta cerca del portal ya que causa problemas
        if (Mathf.Abs(camSpaceDst) > nearClipLimit)
        {
            Vector4 clipPlaneCameraSpace = new Vector4(camSpaceNormal.x, camSpaceNormal.y, camSpaceNormal.z, camSpaceDst);

            // Canvia el near clip plane y lo calcula con la camara de referencia para usar los setings de la camara de este
            this.GetComponent<Camera>().projectionMatrix = referenceCam.CalculateObliqueMatrix(clipPlaneCameraSpace);
        }
        else
        {
            this.GetComponent<Camera>().projectionMatrix = referenceCam.projectionMatrix;
        }
    }

    
}
