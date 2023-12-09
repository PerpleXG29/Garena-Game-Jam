using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DropObject : MonoBehaviour
{
    public bool Cure1 = false;
    public bool Cure2 = false;
    public bool Cure3 = false;

    private int CureCount = 0;

    public PickUp pickUp;

    private void Update()
    {
        Debug.Log(CureCount);
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F) && other.CompareTag("Player"))
        {
            if (pickUp.Cure1 == true || pickUp.Cure2 == true || pickUp.Cure3 == true)
                DropLogic();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Insert Disableing UI
    }

    private void DropLogic()
    {
        if (pickUp.Cure1 == true)
        {
            Cure1 = true;
            Reset();
            CureCount++;
        }
        else if (pickUp.Cure2 == true)
        {
            Cure2 = true;
            Reset();
            CureCount++;
        }
        else if (pickUp.Cure3 == true)
        {
            Cure3 = true;
            Reset();
            CureCount++;
        }
        else
        {
            return;
        }

    }

    private void Reset()
    {
        pickUp.Cure1 = false;
        pickUp.Cure2 = false;
        pickUp.Cure3 = false;
        pickUp.Carrying = false;
    }
}