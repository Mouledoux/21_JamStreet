using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Mediation;

public class LayerCollisionChecks : MonoBehaviour
{
    public string LayerName;

    public List<ZoneTraveler> WhiteList;

    public Catalogue<ZoneTraveler>.Subscription ZoneChange;

    private void Start()
    {
        WhiteList = new List<ZoneTraveler>();
        ZoneChange = new Catalogue<ZoneTraveler>.Subscription("MyZoneChanged", UpdateWhiteList).Subscribe();
    }

    void UpdateWhiteList(ZoneTraveler arg)
    {
        Debug.Log("UPDATE");
        if (arg.PriorityZone == GetComponent<ZoneTraveler>().PriorityZone)
        {
            WhiteList.Add(arg);
            Physics2D.IgnoreCollision(arg.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
