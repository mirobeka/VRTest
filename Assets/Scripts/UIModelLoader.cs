using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIModelLoader : MonoBehaviour
{
    public GameObject[] modelPrefabs = null;
    public GameObject buttonPrefab = null;
    public ObjectSpawner spawner = null;

    void Awake(){
        foreach(GameObject prefab in modelPrefabs)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, transform);
            Button button = buttonObject.GetComponent<Button>();
            TextMeshProUGUI label = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            label.text = prefab.name;

            button.onClick.AddListener(() => SetSpawnPrefab(prefab));
        }
    }

    void SetSpawnPrefab(GameObject prefab){
        spawner.SetNewSpawnee(prefab);
    }

}
