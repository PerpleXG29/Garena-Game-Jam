using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool Cure1 = false;
    public bool Cure2 = false;
    public bool Cure3 = false;
    public bool Carrying = false;

    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cure1") || other.CompareTag("Cure2") || other.CompareTag("Cure3"))
        {
            Debug.Log("InRange");
            if (Input.GetKey(KeyCode.F) && !Carrying)
            {
                PickUpLogic(other.gameObject);
            }
        }
    }

    private void PickUpLogic(GameObject cureObject)
    {
        Debug.Log("Entering Pick UP logic");
        if (cureObject.CompareTag("Cure1"))
        {
            Cure1 = true;
        }
        else if (cureObject.CompareTag("Cure2"))
        {
            Cure2 = true;
        }
        else if (cureObject.CompareTag("Cure3"))
        {
            Cure3 = true;
        }

        Carrying = true;
        Destroy(cureObject);
        Debug.Log("Picked up " + cureObject.tag);
    }
}