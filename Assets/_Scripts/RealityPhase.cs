using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityPhase : MonoBehaviour
{
    public List<RenderLayers> Layers;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ToggleLayer(new System.Object[] { Camera.main, Layers[0] });
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleLayer(new System.Object[] { Camera.main, Layers[1] });
        }
    }

    public void ToggleLayer(System.Object[] args)
    {
        if (args[0].GetType() != typeof(Camera))
        {
            Debug.LogError("First argument must be a camera");
            return;
        }

        foreach (var layer in Layers)
        {
            if (layer == args[1] as RenderLayers)
            {
                layer.EnableLayer(args[0] as Camera);
            }
        }        
    }
}

[System.Serializable]
public class RenderLayers
{
    public string Name;
    public bool IsRendering;
    [SerializeField]
    public UnityEngine.Events.UnityEvent LayerIsRendering;
    public UnityEngine.Events.UnityEvent LayerNotRendering;

    public void EnableLayer(Camera cam)
    {
        cam.cullingMask = cam.cullingMask ^ (1 << LayerMask.NameToLayer(Name));
        IsRendering = !IsRendering;
        if (IsRendering)
            LayerIsRendering.Invoke();
        else
            LayerNotRendering.Invoke();
    }
}