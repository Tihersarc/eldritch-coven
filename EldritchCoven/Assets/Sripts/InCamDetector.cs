using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InCamDetector : MonoBehaviour
{
    [SerializeField] GameObject renderPlane;
    Plane[] cameraFrustum;
    Camera cam;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        Portal.OnTravelPortal += CheckFrustrumVisibility;
    }

    private void OnPreCull()
    {
        renderPlane.layer = 6;
    }

    private void OnPostRender()
    {
        renderPlane.layer = 0;
    }

    private void Update()
    {
        CheckFrustrumVisibility();
    }

    public void CheckFrustrumVisibility()
    {
        if (cam == null)
        {
            cam = gameObject.GetComponent<Camera>();
            
        }
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);

        foreach (MeshRenderer otherRenderPlane in GameLogic.instance.renderPlanes)
        {
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, otherRenderPlane.GetComponent<Collider>().bounds) && (otherRenderPlane.gameObject != renderPlane))
            {
                otherRenderPlane.GetComponent<RenderPlaneRayCaster>().CheckVisibility(cam, renderPlane);
            }
        }

    }

    private void OnDestroy()
    {
        cam = null;
    }
}
