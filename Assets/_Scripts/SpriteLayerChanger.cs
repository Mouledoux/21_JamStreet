using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteLayerChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void SetSpriteOrderInLayer(int layer)
    {
        if (spriteRenderer != null)
            spriteRenderer.sortingOrder = layer;
    }

}
