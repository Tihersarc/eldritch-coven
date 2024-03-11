using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RenderQueue : MonoBehaviour
{
    Renderer renderer;

    private void OnEnable()
    {
        renderer = GetComponent<Renderer>();
        
    }

    private void Update()
    {
        renderer.sharedMaterial.renderQueue = 2000 + renderer.sharedMaterial.GetInt("_StencilID");
    }
}
