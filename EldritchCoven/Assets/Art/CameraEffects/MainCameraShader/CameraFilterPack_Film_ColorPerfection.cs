////////////////////////////////////////////
// CameraFilterPack - by VETASOFT 2020 /////
////////////////////////////////////////////
using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[AddComponentMenu ("Camera Filter Pack/Film/ColorPerfection")]
public class CameraFilterPack_Film_ColorPerfection : MonoBehaviour {
#region Variables
public Shader SCShader;
private float TimeX = 1.0f;
 
private Material SCMaterial;
[Range(0f, 4f)]
public float Gamma = 0.55f;
[Range(0f, 10f)]
private float Value2 = 1f;
[Range(0f, 10f)]
private float Value3 = 1f;
[Range(0f, 10f)]
private float Value4 = 1f;
#endregion
#region Properties
Material material
{
    get
    {
        if(SCMaterial == null)
        {
            SCMaterial = new Material(SCShader);
            SCMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
        return SCMaterial;
    }
}
#endregion
void Start ()
{
SCShader = Shader.Find("CameraFilterPack/Film_ColorPerfection");
if(!SystemInfo.supportsImageEffects)
{
enabled = false;
return;
}
}
void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
{
if(SCShader != null)
{
TimeX+=Time.deltaTime;
if (TimeX>100)  TimeX=0;
material.SetFloat("_TimeX", TimeX);
material.SetFloat("_Value", Gamma);
material.SetFloat("_Value2", Value2);
material.SetFloat("_Value3", Value3);
material.SetFloat("_Value4", Value4);
material.SetVector("_ScreenResolution",new Vector4(sourceTexture.width,sourceTexture.height,0.0f,0.0f));
Graphics.Blit(sourceTexture, destTexture, material);
}
else
{
Graphics.Blit(sourceTexture, destTexture);
}
}
void Update ()
{
#if UNITY_EDITOR
if (Application.isPlaying!=true)
{
SCShader = Shader.Find("CameraFilterPack/Film_ColorPerfection");
}
#endif
}
void OnDisable ()
{
if(SCMaterial)
{
DestroyImmediate(SCMaterial);
}
}
}