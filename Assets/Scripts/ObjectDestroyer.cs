using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public ObjectSpawner objectSpawner = null;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Destroy(col.gameObject);
            objectSpawner.SpawnNewOne();
        }
    }
}
