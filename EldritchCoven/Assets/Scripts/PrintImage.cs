using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintImage : MonoBehaviour
{
    Texture2D texture;

    private void Start()
    {
        texture = new Texture2D(256, 256, TextureFormat.RGB24, false);
    }

    public void ConvertToImage(RenderTexture rTexture)
    {
        RenderTexture.active = rTexture;
        texture.ReadPixels(new Rect(0, 0, rTexture.width, rTexture.height), 0, 0);
    }

    public void ApplyTexture()
    {
        texture.Apply();

        gameObject.GetComponent<Renderer>().material.mainTexture = texture;
    }
}
