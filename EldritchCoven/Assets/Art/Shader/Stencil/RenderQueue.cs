using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RenderQueue : MonoBehaviour
{
    Renderer rendererObj;

    private void OnEnable()
    {
        rendererObj = GetComponent<Renderer>();
        
    }

    private void Update()
    {
        rendererObj.sharedMaterial.renderQueue = 2000 + rendererObj.sharedMaterial.GetInt("_StencilID");
    }
}
