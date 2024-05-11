using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnterTrigger : MonoBehaviour
{
    public static Action OnEnter;
    public UnityEvent OnEnterEvent;
    [SerializeField] GameObject[] gameObjectsToDestroy;
    [SerializeField] RenderPlaneRayCaster portalPlaneToCheck;
    Coroutine coroutine;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            OnEnter?.Invoke();
            OnEnterEvent?.Invoke();

            if (coroutine == null)
            {
                coroutine = StartCoroutine(_CheckPortalInCam());
            }
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
