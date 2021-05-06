using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColliderController : MonoBehaviour
{
    public GameObject targetExplosionEffect = null;

    void Explode()
    {
        Instantiate(targetExplosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Explode();

        }
    }
}
