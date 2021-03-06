using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZoneAbility : ZoneAbility
{
    public float ModifiedGravity;
    public float OGGravity;

    private void Awake()
    {
        if (GetComponent<Gamekit2D.PlayerCharacter>())
        {
            ModifiedGravity = GetComponent<Gamekit2D.PlayerCharacter>().gravity / 2;
            OGGravity = GetComponent<Gamekit2D.PlayerCharacter>().gravity;
            return;
        }
        ModifiedGravity = GetComponent<Rigidbody2D>().gravityScale / 2;
        OGGravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    private void OnEnable()
    {
        if (GetComponent<Gamekit2D.PlayerCharacter>())
        {
            GetComponent<Gamekit2D.PlayerCharacter>().gravity = ModifiedGravity;
            return;
        }
        GetComponent<Rigidbody2D>().gravityScale = ModifiedGravity;
    }

    private void OnDisable()
    {
        if (GetComponent<Gamekit2D.PlayerCharacter>())
        {
            GetComponent<Gamekit2D.PlayerCharacter>().gravity = OGGravity;
            return;
        }
        GetComponent<Rigidbody2D>().gravityScale = OGGravity;
    }
}
