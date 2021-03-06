using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehaviour : MonoBehaviour
{
    public int Influence;

    public enum ZoneType
    {
        Red, Green, Blue, Yellow, Clear
    }

    public ZoneType _ZoneType;

    public void ObjectEnteredZone(GameObject obj)
    {
        if (obj.GetComponent<ZoneTraveler>())
            obj.GetComponent<ZoneTraveler>().OnEnterZone(this);
    }

    public void ObjectExitedZone(GameObject obj)
    {
        if (obj.GetComponent<ZoneTraveler>())
            obj.GetComponent<ZoneTraveler>().OnExitZone(this);
    }
}
