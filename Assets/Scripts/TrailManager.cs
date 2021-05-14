using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    public Rigidbody rb = null;
    public float minVelocity = 10f;

    private TrailRenderer trail = null;
    // Start is called before the first frame update
    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTrailByVelocity();
    }

    private void SetTrailByVelocity()
    {
        if(rb == null)
        {
            return;
        }

        if(rb.velocity.magnitude >= minVelocity){
            trail.emitting = true;
        }else{
            trail.emitting = false;
        }
    }
}
