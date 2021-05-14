using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRandomChild : MonoBehaviour
{
    private int childCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        int randIdx = Random.Range(0, transform.childCount-1);
        transform.GetChild(randIdx).gameObject.SetActive(true);
    }
}
