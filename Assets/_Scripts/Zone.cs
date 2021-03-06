﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public int Influence;

    public enum ZoneType
    {
        Red, Green, Blue, Yellow, Clear, Default
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
