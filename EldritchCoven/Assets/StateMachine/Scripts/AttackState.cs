using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/EnemyStates/AttackState")]
public class AttackState : State
{
    public override void OnEnter()
    {
        stateController.enemy.agent.speed *= 0.5f;
        stateController.GetComponentInChildren<Animator>().SetTrigger("attack");
    }

    public override void OnExit()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
