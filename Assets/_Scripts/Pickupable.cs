using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private bool pickable;
    public GameObject Prompt;
        
    public void DisplayPrompt(bool status)
    {
        Prompt.SetActive(status);
    }
}
