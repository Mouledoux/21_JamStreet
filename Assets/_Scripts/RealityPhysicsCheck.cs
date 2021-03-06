using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityPhysicsCheck : MonoBehaviour
{
    public int PreviousLayer;

    private void Awake()
    {
        PreviousLayer = gameObject.layer;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        if (collision.gameObject.layer != this.gameObject.layer)
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>(), true);
        else
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>(), false);
    }

    private void Update()
    {        
        UpdateRenderLayer();
    }

    void UpdateRenderLayer()
    {
        if(gameObject.layer != PreviousLayer)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up);
        }
        PreviousLayer = gameObject.layer;
    }
}
