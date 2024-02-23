using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Enemy/Decisions/EnemyDetected")]
public class DecisionPlayerDetected : Decision
{
    public override bool Decide(StateController stateController)
    {
        return stateController.enemy.fov.canSeePlayer;
    }
}
