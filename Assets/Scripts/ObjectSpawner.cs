using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spawnee = null;
    private Transform attachTransform = null;
    private GameObject lastSpawned = null;
    private bool bugEnabled = false;
    private GameObject objectDestroyer = null;
    
    void Awake(){
        attachTransform = transform.Find("AttachTransform");
        objectDestroyer = transform.Find("ObjectDestroyer").gameObject;
    }

    void Start(){
        SpawnNewOne();
    }

    public void SpawnNewOne()
    {
        lastSpawned = Instantiate(spawnee, attachTransform.position, Quaternion.identity);
    }

    public void ToggleBug(){
        bugEnabled = !bugEnabled;
        objectDestroyer.SetActive(!bugEnabled);
    }

    void OnTriggerExit(Collider other)
    {
        if (bugEnabled){
            SpawnNewOne();

        }else{
            if(other.gameObject.tag == "Ball")
            {
                SpawnNewOne();
            }
        }

    }

    public void SetNewSpawnee(GameObject newObject)
    {
        Destroy(lastSpawned);
        spawnee = newObject;
        SpawnNewOne();
    }
}
