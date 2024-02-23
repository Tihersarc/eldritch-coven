using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/EnemyStates/Idle")]
public class IdleState : State {
    public override void OnEnter() {
        Debug.Log("EnterIdle");
    }

    public override void OnExit() {
        Debug.Log("ExitIdle");
    }

    public override void UpdateState() {
        Debug.Log("Idle");
    }
}
