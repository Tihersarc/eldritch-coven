using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
        MaterialCheck();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.blue);
    }

    public void PlayWalkEvent()
    {
        //TODO
    }

    public void PlayRunEvent()
    {
        //TODO
    }

    public void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance, mask))
        {
            Debug.Log(hit.collider.tag);
            switch (hit.collider.tag)
            {
                
                case "Wood":
                    Debug.Log("Inside wood");
                    terrainValue = 0;
                    break;
                case "Dirt":
                    Debug.Log("Inside dirt");
                    terrainValue = 1;
                    break;
                default:
                    terrainValue = 3;
                    Debug.LogError("No ground material detected");
                    break;
            }
        }
        //Debug.Log("Terrain: " + terrainValue);
        //stepsEmitter.SetParameter(paramWalkRun, // WALK OR RUN //, false);
        stepsEmitter.SetParameter(paramTerrain, terrainValue, false);
    }
}
