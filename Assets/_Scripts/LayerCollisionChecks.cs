using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Mediation;

public class LayerCollisionChecks : MonoBehaviour
{    
    public List<ZoneTraveler> WhiteList;

    public Catalogue<ZoneTraveler>.Subscription ZoneChange;

    private void Awake()
    {
        WhiteList = new List<ZoneTraveler>();
        ZoneChange = new Catalogue<ZoneTraveler>.Subscription("MyZoneChanged", UpdateWhiteList);
    }

    void UpdateWhiteList(ZoneTraveler arg)
    {
        if (arg != null && arg.PriorityZone != null)
        {
            if (arg.PriorityZone == GetComponent<ZoneTraveler>().PriorityZone && !WhiteList.Contains(arg) && arg != this.GetComponent<ZoneTraveler>())
            {
                WhiteList.Add(arg);
                Physics2D.IgnoreCollision(arg.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
        }
        for(int i = 0; i < WhiteList.Count; i++)
        {
            if(WhiteList[i].PriorityZone != GetComponent<ZoneTraveler>().PriorityZone)
            {
                Physics2D.IgnoreCollision(WhiteList[i].GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
                WhiteList.Remove(WhiteList[i]);
            }
        }
    }


    private void OnEnable()
    {
        ZoneChange.Subscribe();
    }

    private void OnDisable()
    {
        ZoneChange.Unsubscribe();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
