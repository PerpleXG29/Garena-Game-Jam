using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCheckState : ZombieBaseState
{
    public ZombieCheckState(ZombieStateMachine ZSM, Vector3 hearPosition) : base(ZSM)
    {
        this.hearPosition = hearPosition;
    }

    Vector3 hearPosition;
    float checkTime = 0f;
    bool isPlayerVisible = false;

    public override void EnterState()
    {
        ZSM.AIPath.maxSpeed = ZSM.MaxSpeed * 0.75f;
        ZSM.ChangeMaterial(Color.blue);
        ZSM.AIPath.destination = hearPosition;
    }
    public override void UpdateState(float deltaTime)
    {
        if (ZSM.IsPlayerVisible()) ZSM.ChaseTargetEvent();

        checkTime += deltaTime;
        if(checkTime >= ZSM.CheckDuration)
        {
            //Nothing Happens
            ZSM.PatrolEvent();
        }



    }

    public override void ExitState()
    {
        ZSM.AIPath.maxSpeed = ZSM.MaxSpeed;
    }

}
