using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombieBaseState : State
{
    protected ZombieStateMachine ZSM;

    public ZombieBaseState(ZombieStateMachine ZSM)
    {
        this.ZSM = ZSM;
    }
}
