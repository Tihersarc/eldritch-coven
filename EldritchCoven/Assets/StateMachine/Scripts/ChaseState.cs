using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/EnemyStates/ChaseState")]
public class ChaseState : State
{
    public override void OnEnter()
    {
        stateController.enemySoundEmitter.Play();
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
