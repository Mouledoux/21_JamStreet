using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOverlap : MonoBehaviour
{
    [SerializeField]
    public OverlapEvent OnObjectOverlap;
    [SerializeField]
    public OverlapEvent OnObjectLeaveOverlap;    

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnObjectOverlap.Invoke(other.gameObject);
    }    

    private void OnTriggerExit2D(Collider2D other)
    {
        OnObjectLeaveOverlap.Invoke(other.gameObject);
    }
}

[System.Serializable]
public class OverlapEvent : UnityEngine.Events.UnityEvent<GameObject> { }