using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    public void SwitchState(State nextState)
    {
        currentState?.ExitState();
        currentState = nextState;
        currentState?.EnterState();
    }

    private void Update()
    {
        currentState.UpdateState(Time.deltaTime);
    }

}
