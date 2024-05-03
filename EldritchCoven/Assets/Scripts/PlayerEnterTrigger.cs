using System;
using System.Collections;
using UnityEngine;

public class PlayerEnterTrigger : MonoBehaviour
{
    public static Action OnEnter;
    [SerializeField] GameObject[] gameObjectsToDestroy;
    [SerializeField] RenderPlaneRayCaster portalPlaneToCheck;
    Coroutine coroutine;

    bool once = false;


    private void OnTriggerEnter(Collider other)
    {
        OnEnter?.Invoke();

        if (coroutine == null)
        {
            coroutine = StartCoroutine(_CheckPortalInCam());
        }
    }
    IEnumerator _CheckPortalInCam()
    {
        Physics.SyncTransforms();
        while (CheckFrustrumVisibility())
        {
            yield return null;
        }


        foreach (GameObject obj in gameObjectsToDestroy)
        {
            obj.SetActive(false);
        }
    }

    private bool CheckFrustrumVisibility()
    {
        Plane[] cameraFrustum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(cameraFrustum, portalPlaneToCheck.GetComponent<Collider>().bounds);

    }
}
