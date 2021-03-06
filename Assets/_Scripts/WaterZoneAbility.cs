using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZoneAbility : ZoneAbility
{
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.25f;
    }

    private void OnDestroy()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
