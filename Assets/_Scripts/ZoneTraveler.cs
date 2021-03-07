using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Mediation;
[RequireComponent(typeof(Rigidbody2D))]
public class ZoneTraveler : MonoBehaviour
{
    public List<Zone> OverlappedZones;
    public Zone PriorityZone;

    public List<ZoneAbility> Abilities;    
    public ZoneAbility ActiveAbility;

    virtual public void OnEnterZone(Zone zone)
    {
        if (!OverlappedZones.Contains(zone))      
            OverlappedZones.Add(zone);
        FindPrioityZone();
    }

    virtual public void OnExitZone(Zone zone)
    {
        if (OverlappedZones.Contains(zone))
            OverlappedZones.Remove(zone);
        FindPrioityZone();
    }

    private void Update()
    {
        if(PriorityZone != null && ActiveAbility != null)
            if (PriorityZone._CurrentType != ActiveAbility.ZoneRestriction)
            {
                ActiveAbility.enabled = false;
                ActiveAbility = null;
            }
    }

    void FindPrioityZone()
    {
        if (OverlappedZones.Count == 0)
        {
            PriorityZone = null;
            ActiveAbility = null;
            GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            return;
        }
        Zone mostInfluence = OverlappedZones[OverlappedZones.Count - 1];
        foreach (var zone in OverlappedZones)
        {
            if (zone.Influence > mostInfluence.Influence)
                mostInfluence = zone;
        }
        PriorityZone = mostInfluence;
        Debug.Log("SHOUT");
        Catalogue<ZoneTraveler>.NotifySubscribers("MyZoneChanged", this as ZoneTraveler);
        foreach (var ability in Abilities)
        {
            if (ability.ZoneRestriction == PriorityZone._CurrentType)
            {
                if(ActiveAbility != null)
                    ActiveAbility.enabled = false;
                ability.enabled = true;
                ActiveAbility = ability;                      
                return;
            }
        }
        if (ActiveAbility == null || PriorityZone == null)
        {
            return;
        }
        if (PriorityZone._CurrentType != ActiveAbility.ZoneRestriction)
        {
            ActiveAbility.enabled = false;
            ActiveAbility = null;
        }
    }
}
