using FMODUnity;
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
                    Debug.LogWarning("No ground material detected");
                    terrainValue = 3;
                    break;
            }
        }

        stepsEmitter.SetParameter(paramTerrain, terrainValue, false);
    }
}
