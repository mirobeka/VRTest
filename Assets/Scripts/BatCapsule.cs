using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsule : MonoBehaviour
{
    public BatCapsuleFollower _batCapsuleFollowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBatCapsuleFollower();
    }

    private void SpawnBatCapsuleFollower()
    {
        var follower = Instantiate(_batCapsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.transform.rotation = transform.rotation;
        follower.SetFollowTarget(this);
    }

}
