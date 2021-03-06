using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public Pickupable ActivePickup;
    public Transform GrabLocation;

    public void PickupPrompt(GameObject obj)
    {
        if(obj.GetComponent<Pickupable>())
        {
            obj.GetComponent<Pickupable>().DisplayPrompt(true);
        }
    }

    public void StopPickupPrompt(GameObject obj)
    {
        if (obj.GetComponent<Pickupable>())
        {
            obj.GetComponent<Pickupable>().DisplayPrompt(false);
        }
    }
}
