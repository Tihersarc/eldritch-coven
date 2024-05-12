using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/EnemyStates/Idle")]
public class IdleState : State {
    public override void OnEnter() {

    }

    public override void OnExit() {
        
    }

    public override void UpdateState() {
        Transform enemyTransform = stateController.gameObject.transform;
        Vector3 enemyNewForward = GameLogic.instance.playerController.transform.position - enemyTransform.position;
        enemyNewForward.z += -1f;
        enemyTransform.rotation = Quaternion.LookRotation(enemyNewForward);
    }
}
