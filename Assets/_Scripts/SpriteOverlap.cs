using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOverlap : MonoBehaviour
{    
    public List<GameObject> Overlapped;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Overlapped.Add(other.gameObject);
    }    

    private void OnTriggerStay(Collider2D other)
    {
        if (Overlapped.Contains(other.gameObject))
            return;        
        Overlapped.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider2D other)
    {
        if (Overlapped.Contains(other.gameObject))            
            Overlapped.Remove(other.gameObject);
    }
}
