using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "StateMachine/Enemy/EnemyStates/PatrolState")]
public class PatrolState : State
{
    NavMeshAgent agent;
    [SerializeField] private float range;
    private Transform centrePoint;

    public override void OnEnter()
    {
        agent = stateController.GetComponent<NavMeshAgent>();
        centrePoint = stateController.transform;
        Debug.Log("Start Patrol");
    }

    public override void OnExit()
    {
        Debug.Log("Ends Patrol");
    }

    public override void UpdateState()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
