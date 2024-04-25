using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PortalTextureSetup : MonoBehaviour
{
    private static PortalTextureSetup portalTextureSetup;

    public static PortalTextureSetup instance
    {
        get
        {
            return RequestInstance();
        }
    }

    static PortalTextureSetup RequestInstance()
    {

        if (portalTextureSetup == null)
        {
            portalTextureSetup = FindObjectOfType<PortalTextureSetup>();

            if (portalTextureSetup == null)
            {
                GameObject gamelogicObject = new GameObject("PortalTextureSetup");
                portalTextureSetup = gamelogicObject.AddComponent<PortalTextureSetup>();
            }
        }
        return portalTextureSetup;
    }

    [SerializeField] private GameObject[] portals;

    private void Awake()
    {
        foreach (var portal in portals)
        {
            Camera portalCamera = portal.GetComponentInChildren<Camera>();

            if (portalCamera.targetTexture != null)
            {
                portalCamera.targetTexture.Release();
            }

            Portal portalBehaviour = portal.GetComponent<Portal>();

            //Creamos una rendertexture con el tamaño adecuado de la camara/pantalla
            portalCamera.targetTexture = new RenderTexture(1920, 1080, 0);
            portalBehaviour.exit.screen.material.mainTexture = portalCamera.targetTexture;
        }
    }

    public void AddPortal(GameObject portal)
    {
#if UNITY_EDITOR
        Undo.RegisterCompleteObjectUndo(this, "AssignPortal");
        GameObject[] auxPortals = new GameObject[portals.Length + 1];
        portals.CopyTo(auxPortals, 0);
        auxPortals[portals.Length] = portal;
        portals = auxPortals;
#endif
    }
}
