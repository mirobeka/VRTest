using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}

