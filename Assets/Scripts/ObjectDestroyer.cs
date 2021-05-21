using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private ObjectSpawner objectSpawner = null;

    void Awake()
    {
        objectSpawner = transform.parent.gameObject.GetComponent<ObjectSpawner>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Destroy(col.gameObject);
            objectSpawner.SpawnNewOne();
        }
    }
}
