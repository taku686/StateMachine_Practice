using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private static readonly StateSpiralShell stateSpiralShell = new StateSpiralShell();
    private static readonly StateMovingSpiralShell stateMovingSpiralShell = new StateMovingSpiralShell();
    private static readonly StateIdle stateIdle = new StateIdle();

    private PlayerStateBase currentState = stateIdle;

    private void OnStart()
    {
        currentState.OnEnter(this, null);
    }

    private void OnUpdate()
    {
        currentState.OnUpdate(this);
    }

    private void ChangeState(PlayerStateBase nextState)
    {
        currentState.OnExit(this, nextState);
        nextState.OnEnter(this, currentState);
        currentState = nextState;
    }
}
