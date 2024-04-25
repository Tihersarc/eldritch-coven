using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPlaneRayCaster : MonoBehaviour
{
    [SerializeField] Transform[] cornerPoints;
    [SerializeField] LayerMask portalLayer;

    public bool CheckVisibility(Camera camera, GameObject observer)
    {
        int i = 0;
        bool visible = false;

        this.gameObject.layer = 2;

        while (i < cornerPoints.Length && !visible)
        {
            Vector3 direction = camera.transform.position - cornerPoints[i].position;

            RaycastHit hit;

            if (Physics.Raycast(cornerPoints[i].position, direction, out hit, 1000f, portalLayer))
            {
                Debug.DrawRay(cornerPoints[i].position, direction.normalized * hit.distance, Color.red);

                if (hit.transform.gameObject == observer)
                {
                    
                    Portal portal = GetComponentInParent<Portal>();

                    if (portal != null)
                    {
                        if (portal.exit.ReferenceCam != camera)
                        {
                            portal.exit.ReferenceCam = camera;
                            if (camera != Camera.main) camera.GetComponent<PortalCamera>().MoveCamera();
                            camera.GetComponent<InCamDetector>().CheckFrustrumVisibility();
                            visible = true;
                        }
                    }
                }
            }

            i++;
        }

        this.gameObject.layer = 0;


        return visible;
    }
}
