using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {
    [SerializeField] State firstState;
    [SerializeField] public State currentState;
    public Enemy enemy;// { get; private set; }

    void Start() {
        ChangeState(firstState);
        enemy = GetComponent<Enemy>();
    }

    void Update() {
        currentState.UpdateState();
        State newState = currentState.CheckTransitions();
        if (newState != null) {
            ChangeState(newState);
        }
    }

    void ChangeState(State newState) {
        if (currentState != null) {
            currentState.OnExit();
            Destroy(currentState);
        }
        currentState = Instantiate(newState);
        currentState.SetStateController(this);
        currentState.OnEnter();
    }
    public bool CurrentStateIsDone() {
        return currentState.isDone;
    }

}
