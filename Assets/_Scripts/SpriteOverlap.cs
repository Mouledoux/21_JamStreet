using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOverlap : MonoBehaviour
{
    [SerializeField]
    public OverlapEvent OnObjectOverlap;
    [SerializeField]
    public OverlapEvent OnObjectLeaveOverlap;

    [Tooltip("Leave Empty if no tag restrictions")]
    public List<string> CollisionTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(CollisionTags.Count == 0 || CollisionTags.Contains(other.tag))
            OnObjectOverlap.Invoke(other.gameObject);        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (CollisionTags.Count == 0 || CollisionTags.Contains(other.tag))
            OnObjectLeaveOverlap.Invoke(other.gameObject);
    }
}

[System.Serializable]
public class OverlapEvent : UnityEngine.Events.UnityEvent<GameObject> { }