using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolState : ZombieBaseState
{
    public ZombiePatrolState(ZombieStateMachine ZSM) : base(ZSM) { }

    Vector3 searchedPosition;
    float timeCounter = 0f;
    public override void EnterState()
    {
        ZSM.ChangeMaterial(Color.red);

        GetRandomPatrolPosition();
        ZSM.AIPath.destination = searchedPosition;
    }
    public override void UpdateState(float deltaTime)
    {
        if (ZSM.IsPlayerVisible()) ZSM.SeeTargetEvent();


        if (!ZSM.AIPath.reachedEndOfPath) return;
        timeCounter += deltaTime;

        if(timeCounter >= ZSM.PatrolDuration)
        {
            GetRandomPatrolPosition();
            timeCounter = 0f;

            ZSM.AIPath.destination = searchedPosition;
        }

    }

    public override void ExitState()
    {
        
    }


    private void GetRandomPatrolPosition()
    {
        float xPos = Random.Range(ZSM.SpawnLocation.position.x - ZSM.PatrolDistance, ZSM.SpawnLocation.position.x + ZSM.PatrolDistance);
        float zPos = Random.Range(ZSM.SpawnLocation.position.z - ZSM.PatrolDistance, ZSM.SpawnLocation.position.z + ZSM.PatrolDistance);


        searchedPosition = new Vector3(xPos, 0f, zPos);
    }

}
