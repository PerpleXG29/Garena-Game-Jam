using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class ZombieStateMachine : StateMachine
{
    [Header("Zombie Attributes")]
    public float MaxSpeed;
    public float HearRange;
    public float SeeRange;
    public float fieldOfViewSize = 60f;

    [Space(5)]
    [Header("Patrol Attributes")]
    public float PatrolDistance;
    public float PatrolDuration;

    [Space(5)]
    [Header("Check Attributes")]
    public float CheckDuration;

    [Space(5)]
    [Header("Chase Attributes")]
    public float ChaseDuration;

    [Space(5)]
    [Header("Shriek Attributes")]
    public float ShriekDistance;
    public float ShriekDuration;


    [Header("Reference")]
    public LayerMask ZombieLayerMask;
    public LayerMask PlayerLayerMask;
    public AIPath AIPath;
    public Transform SpawnLocation;
    public Transform eyeTransform;

    public Target Target;

    public bool IsChasing = false;

    Material zombieMaterial;
    private void Start()
    {
        zombieMaterial = GetComponent<MeshRenderer>().material;

        SwitchState(new ZombiePatrolState(this));
        AIPath.maxSpeed = MaxSpeed;


    }


    
    public void SeeTargetEvent()
    {
        SwitchState(new ZombieShriekState(this));
    }

    public void HearTargetEvent(Vector3 position)
    {
        SwitchState(new ZombieCheckState(this, position));
    }
    
    public void ChaseTargetEvent()
    {
        SwitchState(new ZombieChaseState(this));
    }

    public void PatrolEvent()
    {
        SwitchState(new ZombiePatrolState(this));
    }

    public void ChangeMaterial(Color color)
    {
        zombieMaterial.color = color;
    }

    public bool IsPlayerVisible()
    {
        if (Target == null) return false;

        RaycastHit hit;
        Vector3 rayDirection =  Target.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewSize * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, SeeRange))
            {
                return (hit.collider.GetComponent<Target>());
            }
        }

        return false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(SpawnLocation.position, PatrolDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(eyeTransform.position, Vector3.forward * SeeRange);
    }


}
