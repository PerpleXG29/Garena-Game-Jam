using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShriekState : ZombieBaseState
{
    public ZombieShriekState(ZombieStateMachine ZSM) : base(ZSM) { }

    float timeCount = 0f;
    public override void EnterState()
    {
        //TODO: CHANGE THIS AFTER
        ZSM.ChangeMaterial(Color.yellow);
        ZSM.AIPath.canMove = false;
        GetAllZombieNear();
    }
    public override void UpdateState(float deltaTime)
    {
        timeCount += deltaTime;
        if(timeCount >= ZSM.ShriekDuration)
        {
            ZSM.ChaseTargetEvent();
        }

        ZSM.transform.LookAt(ZSM.Target.transform.position, Vector3.up);
    }

    public override void ExitState()
    {
        ZSM.AIPath.canMove = true;
    }

    private void GetAllZombieNear()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(ZSM.transform.position, ZSM.ShriekDistance, ZSM.transform.forward, ZSM.ZombieLayerMask);

        foreach(RaycastHit hit in raycastHits)
        {
            if (hit.collider.GetComponent<ZombieStateMachine>() == ZSM) continue;
            ZombieStateMachine  newZSM =  hit.collider.GetComponent<ZombieStateMachine>();

            if (newZSM == null) continue;
            newZSM.HearTargetEvent(ZSM.transform.position);
        }

    }

}
