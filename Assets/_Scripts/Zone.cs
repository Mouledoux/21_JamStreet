using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public int Influence;    
    public enum ZoneType
    {
        Red, Green, Blue, Yellow, Clear, Default
    }

    [SerializeField]
    private ZoneType _ZoneType;
    [HideInInspector]
    public ZoneType _CurrentType;
    public Color GlassColor;    

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = Color.clear;
        GetComponent<SpriteMask>().enabled = false;
    }

    [ContextMenu("Unlock")]
    public void OpenZone()
    {
        GetComponent<SpriteRenderer>().color = GlassColor;
        GetComponent<SpriteMask>().enabled = true;
        _CurrentType = _ZoneType;
    }

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
