using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsPlayer : MonoBehaviour
{
    //https://youtu.be/fT32r1dvO_I?feature=shared&t=541 TODO
    private int terrainValue;
    private RaycastHit hit;
    private float distance = 1f;
    private string eventPath = ""; //???????
    private readonly string paramTerrain = "Terrain";
    private readonly string paramWalkRun = "WalkRun";
    private LayerMask mask;

    private EventDescription eventDescription;
    private PARAMETER_DESCRIPTION paramDescription;

    void Start()
    {
        mask = LayerMask.GetMask("Ground");
    }


    void Update()
    {
        
    }

    public void PlayWalkEvent()
    {
        MaterialCheck();

        EventInstance walk = RuntimeManager.CreateInstance(eventPath);
        RuntimeManager.AttachInstanceToGameObject(walk, transform, GetComponent<Rigidbody>());

        walk.setParameterByName(paramWalkRun, terrainValue, false);
        walk.setParameterByName(paramTerrain, terrainValue, false);

        walk.start();
        //walk.release(); //????????
    }

    public void PlayRunEvent()
    {
        //TODO
    }
    private void MaterialCheck()
    {
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance, mask))
        {
            switch (hit.collider.tag)
            {
                case "Wood":
                    terrainValue = 0;
                    break;
                case "Dirt":
                    terrainValue = 1;
                    break;
                default:
                    terrainValue = 0;
                    Debug.LogError("No ground material detected");
                    break;
            }
        }
    }
}
