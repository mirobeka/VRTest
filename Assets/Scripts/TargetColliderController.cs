using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        // daj naspat bug
        // if (col.gameObject.tag == "Ball")
        // {
        //     Explode();
        // }else
        if (col.gameObject.tag == "BigTarget")
        {
            Explode();
            // pocitaj body

        }

    }
}
