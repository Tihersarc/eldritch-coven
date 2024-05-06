using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintImage : MonoBehaviour
{
    [SerializeField] int[] resolution = new int[2] {1920, 1080};
    Texture2D texture;

    private void Start()
    {
        texture = new Texture2D(resolution[0], resolution[1], TextureFormat.RGB24, false);
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
