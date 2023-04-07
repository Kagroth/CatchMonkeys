using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State currentState;

    public void Init(State initState) {
        currentState = initState;
        currentState.Enter();
    }

    public void ChangeState(State newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update() {
        currentState.Update();
    }

    public void FixedUpdate() {
        currentState.FixedUpdate();
    }

    public void LateUpdate() {
        currentState.LateUpdate();
    }
}
