using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InCamDetector : MonoBehaviour
{
    [SerializeField] GameObject renderPlane;
    Plane[] cameraFrustum;
    Camera cam;
    [SerializeField] int portalPlaneLayer;

    private void Awake()
    {
        cam = this.gameObject.GetComponent<Camera>();
        Portal.OnTravelPortal += CheckFrustrumVisibility;
    }

    private void OnPreCull()
    {
        renderPlane.layer = portalPlaneLayer;
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
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);

        foreach (MeshRenderer otherRenderPlane in GameLogic.instance.renderPlanes)
        {
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, otherRenderPlane.GetComponent<Collider>().bounds) && (otherRenderPlane.gameObject != renderPlane))
            {
                otherRenderPlane.GetComponent<RenderPlaneRayCaster>().CheckVisibility(cam, renderPlane);
            }
        }

    }
}
