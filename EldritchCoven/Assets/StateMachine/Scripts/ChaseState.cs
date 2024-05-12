using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/EnemyStates/ChaseState")]
public class ChaseState : State
{
    public override void OnEnter()
    {
        stateController.gameObject.transform.Rotate(new Vector3(90f, 0f, 0f));
        stateController.GetComponentInChildren<Animator>().SetTrigger("chase");
    }

    public override void OnExit()
    {
        
    }

    public override void UpdateState()
    {
        stateController.enemy.agent.SetDestination(stateController.enemy.player.transform.position);
    }
}
