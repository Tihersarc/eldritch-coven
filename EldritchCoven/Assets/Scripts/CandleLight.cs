using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    Light light;

    [SerializeField]
    [Range(0.0f, 0.1f)]
    float timeInterval = 0.1f;

    [SerializeField]
    [Range(0.0f, 0.1f)]
    float maxOffset = 0.1f;

    void Start()
    {
        light = GetComponent<Light>();
        InvokeRepeating("FlameMovement", 0f, timeInterval);
    }

    void Update()
    {
        //transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        //light.intensity += Random.Range(-0.05f, 0.05f);
        //Mathf.Clamp(light.intensity, light.intensity - 0.1f, light.intensity + 0.1f);
    }

    void FlameMovement()
    {
        transform.localPosition = new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset));
        light.intensity += Random.Range(-0.05f, 0.05f);
        Mathf.Clamp(light.intensity, light.intensity - 0.05f, light.intensity + 0.05f);
    }
}
