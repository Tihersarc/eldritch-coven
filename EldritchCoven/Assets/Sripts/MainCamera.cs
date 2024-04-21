using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public delegate void RenderPortals();
    public static event RenderPortals renderPortals;

    private void OnPreCull()
    {
        renderPortals?.Invoke();
        Physics.SyncTransforms();
    }
}
