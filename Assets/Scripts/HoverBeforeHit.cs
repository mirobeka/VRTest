using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBeforeHit : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnCollisionEnter(Collision col)
    {
        rb.useGravity = true;
    }
}

