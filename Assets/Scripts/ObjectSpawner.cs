using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spawnee = null;
    private Transform attachTransform = null;
    private GameObject lastSpawned = null;
    
    void Awake(){
        attachTransform = transform.Find("AttachTransform");
    }

    void Start(){
        SpawnNewOne();
    }

    public void SpawnNewOne()
    {
        lastSpawned = Instantiate(spawnee, attachTransform.position, Quaternion.identity);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            SpawnNewOne();
        }

    }

    public void SetNewSpawnee(GameObject newObject)
    {
        Destroy(lastSpawned);
        spawnee = newObject;
        SpawnNewOne();
    }
}