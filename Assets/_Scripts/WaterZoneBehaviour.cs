using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZoneBehaviour : ZoneTraveler
{
    private void LateUpdate()
    {
        if (PriorityZone == null)
            return;
        if (PriorityZone._ZoneType != ZoneBehaviour.ZoneType.Blue)
            this.enabled = false;
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    }
}
