using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

//[ExecuteInEditMode]
[AddComponentMenu("Image Effects/GlitchEffect")]
[RequireComponent(typeof(Camera))]
public class GlitchEffect : MonoBehaviour
{
    public Texture2D displacementMap;
    public Shader Shader;
    [Header("Glitch Intensity")]

    [Range(0, 1)]
    public float intensity;

    [Range(0, 1)]
    public float flipIntensity;

    [Range(0, 1)]
    public float colorIntensity;

    private float _glitchup;
    private float _glitchdown;
    private float flicker;
    private float _glitchupTime = 0.05f;
    private float _glitchdownTime = 0.05f;
    private float _flickerTime = 0.5f;
    private Material _material;

    [SerializeField] AnimationCurve colorIntensityCurve;
    [SerializeField] float colorIntensityCurveDuration;
    float maxIntensity = 0.4f;
    float colorIntensityCurveTimer;

    [SerializeField] float raycastDistance = 4.0f;

    [HideInInspector] public bool glitching = false;
    [HideInInspector] public GameObject propInCam; 

    void Start()
    {
        maxIntensity = intensity;
        _material = new Material(Shader);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (CheckIfMonsterPropInFrustrum())
        {
            glitching = true;
            _material.SetFloat("_Intensity", intensity);
            _material.SetFloat("_ColorIntensity", colorIntensity);
            _material.SetTexture("_DispTex", displacementMap);
            //HandleMaterialValuesIncrease();

            flicker += Time.deltaTime * colorIntensity;
            if (flicker > _flickerTime)
            {
                _material.SetFloat("filterRadius", Random.Range(-3f, 3f) * colorIntensity);
                _material.SetVector("direction", Quaternion.AngleAxis(Random.Range(0, 360) * colorIntensity, Vector3.forward) * Vector4.one);
                flicker = 0;
                _flickerTime = Random.value;
            }

            if (colorIntensity == 0)
                _material.SetFloat("filterRadius", 0);

            _glitchup += Time.deltaTime * flipIntensity;
            if (_glitchup > _glitchupTime)
            {
                if (Random.value < 0.1f * flipIntensity)
                    _material.SetFloat("flip_up", Random.Range(0, 1f) * flipIntensity);
                else
                    _material.SetFloat("flip_up", 0);

                _glitchup = 0;
                _glitchupTime = Random.value / 10f;
            }

            if (flipIntensity == 0)
                _material.SetFloat("flip_up", 0);

            _glitchdown += Time.deltaTime * flipIntensity;
            if (_glitchdown > _glitchdownTime)
            {
                if (Random.value < 0.1f * flipIntensity)
                    _material.SetFloat("flip_down", 1 - Random.Range(0, 1f) * flipIntensity);
                else
                    _material.SetFloat("flip_down", 1);

                _glitchdown = 0;
                _glitchdownTime = Random.value / 10f;
            }

            if (flipIntensity == 0)
                _material.SetFloat("flip_down", 1);

            if (Random.value < 0.05 * intensity)
            {
                _material.SetFloat("displace", Random.value * intensity);
                _material.SetFloat("scale", 1 - Random.value * intensity);
            }
            else
                _material.SetFloat("displace", 0);

            Graphics.Blit(source, destination, _material);
        }
        else
        {
            glitching = false;
            Graphics.Blit(source, destination);
        }
    }

    Vector3 pos = Vector3.zero;

    bool CheckIfMonsterPropInFrustrum()
    {
        bool enemyPropInCam = false;

        RaycastHit[] hits = Physics.BoxCastAll(this.transform.position, new Vector3(.5f, .5f, .5f), this.transform.forward, Quaternion.identity, raycastDistance);

        foreach (RaycastHit hit in hits)
        {
            if(hit.transform.gameObject.tag == "GlitchedProp")
            {
                pos = hit.transform.position;
                RaycastHit checkHit;
                if(Physics.Raycast(hit.transform.position, this.transform.position - hit.transform.position, out checkHit, Mathf.Infinity))
                {
                    enemyPropInCam = checkHit.transform.name == "Player";
                    propInCam = hit.transform.gameObject;
                    break;
                }
                else
                {
                    propInCam = null;
                }

            }
            else
            {
                propInCam = null;
            }
        }

        return enemyPropInCam;
    }

    private void OnDrawGizmos()
    {
        if(pos != Vector3.zero)
            Gizmos.DrawRay(pos, this.transform.position - pos);
    }
}
