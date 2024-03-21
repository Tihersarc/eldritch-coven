using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTextureSetup : MonoBehaviour
{
    private static MirrorTextureSetup mirrorTextureSetup;

    public static MirrorTextureSetup instance
    {
        get
        {
            return RequestInstance();
        }
    }

    static MirrorTextureSetup RequestInstance()
    {

        if (mirrorTextureSetup == null)
        {
            mirrorTextureSetup = FindObjectOfType<MirrorTextureSetup>();

            if (mirrorTextureSetup == null)
            {
                GameObject gamelogicObject = new GameObject("MirrorTextureSetup");
                mirrorTextureSetup = gamelogicObject.AddComponent<MirrorTextureSetup>();
            }
        }
        return mirrorTextureSetup;
    }

    [SerializeField] private GameObject[] mirrors;

    private void Awake()
    {
        foreach (GameObject mirror in mirrors)
        {
            Camera mirrorCamera = mirror.GetComponentInChildren<Camera>();

            if (mirrorCamera.targetTexture != null)
            {
                mirrorCamera.targetTexture.Release();
            }

            mirrorCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 0);
            Transform plane = mirror.transform.Find("squared_mirror").transform.Find("Plane");
            plane.gameObject.GetComponent<MeshRenderer>().material.mainTexture = mirrorCamera.targetTexture;
        }
    }
}
