using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChaseState : ZombieBaseState
{
    public ZombieChaseState(ZombieStateMachine ZSM) : base(ZSM) { }
    const float turnSpeed = 30f;

    float checkTime;

    float attackCooldown = 2f;
    float rampageTimer = 3f;

    float rampageCountdown;
    float countDownCooldown;
    bool isRageDone;
    public override void EnterState()
    {
        ZSM.IsChasing = true;
        ZSM.SpawnManager.CheckForSong();
        ZSM.ChangeMaterial(Color.green);

        ZSM.AIPath.destination = ZSM.Target.transform.position;
        countDownCooldown = attackCooldown;
        rampageCountdown = rampageTimer;
    }


    public override void UpdateState(float deltaTime)
    {
        //RAGE
        if(!isRageDone)
        {
            ZSM.AIPath.destination = ZSM.Target.transform.position;
            countDownCooldown--;
        }

        if (countDownCooldown <= 0f) isRageDone = true;


        if (!isRageDone) return;

        //NormalChase
        Vector3 rayDirection = ZSM.Target.transform.position - ZSM.transform.position;

        RaycastHit hit;
        Physics.Raycast(ZSM.transform.position, rayDirection, out hit, ZSM.SeeRange, ZSM.PlayerLayerMask);

        if (hit.collider || ZSM.IsPlayerVisible())
        {
            GetAllZombieNear();
            //Check if player is visible and still far away
            Vector3 tempTargetPos = new Vector3(ZSM.Target.transform.position.x, 0f, ZSM.Target.transform.position.z);
            Vector3 tempZombiePos = new Vector3(ZSM.transform.position.x, 0f, ZSM.transform.position.z);

            if (Vector3.Distance(tempTargetPos, tempZombiePos) >= 3f)
            {

                ZSM.AIPath.canMove = true;
                ZSM.AIPath.destination = ZSM.Target.transform.position;
            }
            else
            {
                //Play Attack Animation Here!
                ZSM.AIPath.canMove = false;
                ZSM.transform.LookAt(ZSM.Target.transform.position, Vector3.up);

                if(countDownCooldown <= 0f)
                {
                    HealthPoint.Instance.ReduceDamage(1);
                    countDownCooldown = attackCooldown;
                }
                countDownCooldown -= deltaTime;


            }
            checkTime = 0f;
        }
        else 
        {

            checkTime += deltaTime;
        }
         
        if(checkTime >= ZSM.ChaseDuration)
        {
            ZSM.PatrolEvent();
        }

    }

    public override void ExitState()
    {
        ZSM.IsChasing = false;
        ZSM.AIPath.canMove = true;
        ZSM.SpawnManager.CheckForSong();
    }

    private void GetAllZombieNear()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(ZSM.transform.position, ZSM.ShriekDistance, ZSM.transform.forward, ZSM.ZombieLayerMask);

        foreach (RaycastHit hit in raycastHits)
        {
            if (hit.collider.GetComponent<ZombieStateMachine>() == ZSM) continue;

            ZombieStateMachine newZSM = hit.collider.GetComponent<ZombieStateMachine>();
            if (newZSM == null) continue;
            if (newZSM.IsChasing == true) continue;
            newZSM.ChaseTargetEvent();
        }

    }
}
