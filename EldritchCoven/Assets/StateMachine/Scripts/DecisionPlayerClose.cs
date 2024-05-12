using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Decisions/EnemyClose")]
public class DecisionPlayerClose : Decision
{
    public override bool Decide(StateController stateController)
    {
        return stateController.enemy.PlayerInAttackRange();
    }
}
