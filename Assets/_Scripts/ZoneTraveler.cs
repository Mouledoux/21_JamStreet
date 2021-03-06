using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTraveler : MonoBehaviour
{
    public List<ZoneBehaviour> OverlappedZones;
    public ZoneBehaviour PriorityZone;

    virtual public void OnEnterZone(ZoneBehaviour zone)
    {
        if (!OverlappedZones.Contains(zone))      
            OverlappedZones.Add(zone);
        FindPrioityZone();
    }

    virtual public void OnExitZone(ZoneBehaviour zone)
    {
        if (OverlappedZones.Contains(zone))
            OverlappedZones.Remove(zone);
        FindPrioityZone();
    }    

    void FindPrioityZone()
    {
        if (OverlappedZones.Count == 0)
        {
            PriorityZone = null;
            return;
        }
        ZoneBehaviour mostInfluence = OverlappedZones[OverlappedZones.Count - 1];
        foreach (var zone in OverlappedZones)
        {
            if (zone.Influence > mostInfluence.Influence)
                mostInfluence = zone;
        }
        PriorityZone = mostInfluence;
    }
}
