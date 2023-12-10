using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerResetEnemies : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        ZombieStateMachine zsm = other.GetComponent<ZombieStateMachine>();
        Debug.Log(zsm);
        if (zsm != null)
        {
            zsm.PatrolEvent();
        }
    }
}
