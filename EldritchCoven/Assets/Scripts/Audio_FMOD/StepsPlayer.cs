using FMODUnity;
using System;
using UnityEngine;

public class StepsPlayer : MonoBehaviour
{
    //https://youtu.be/fT32r1dvO_I?feature=shared&t=541 TODO

    private readonly string paramTerrain = "Terrain";
    private readonly string paramWalkRun = "WalkRun";

    private LayerMask mask;
    private RaycastHit hit;
    private int terrainValue;

    [SerializeField] private float distance = .5f;
    [SerializeField] StudioEventEmitter stepsEmitter;

    void Start()
    {
        mask = LayerMask.GetMask("Ground");
        //MaterialCheck();
    }

    //void Update()
    //{
    //    Debug.DrawRay(transform.position, Vector3.down, Color.blue);
    //}

    public void PlayWalkEvent()
    {
        stepsEmitter.SetParameter(paramWalkRun, 0, false);
    }

    public void PlayRunEvent()
    {
        stepsEmitter.SetParameter(paramWalkRun, 1, false);
    }

    public void MaterialCheck(bool debug = false)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance, mask))
        {
            if (debug) Debug.Log(hit.collider.tag);
            switch (hit.collider.tag)
            {

                case "Wood":
                    if (debug)
                    {
                        Debug.Log("Inside wood");
                    }
                    terrainValue = 0;
                    break;
                case "Dirt":
                    if (debug)
                    {
                        Debug.Log("Inside dirt");
                    }
                    terrainValue = 1;
                    break;
                default:
                    if (debug)
                    {
                        Debug.LogWarning("No ground material detected");
                    }
                    terrainValue = 2;
                    break;
            }
        }

        if (debug) Debug.Log("Param" + paramTerrain + " set to " + terrainValue);

        stepsEmitter.SetParameter(paramTerrain, terrainValue, true);
    }
}
