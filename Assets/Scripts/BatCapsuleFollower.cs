using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour
{
    public float sensitivity = 100f;

    private BatCapsule batFollower;
    private Rigidbody rigidBody;
    private Vector3 velocity;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rigidBody.position = batFollower.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 destination = batFollower.transform.position;
        velocity = (destination - rigidBody.position) * sensitivity;
        rigidBody.velocity = velocity;
        transform.rotation = batFollower.transform.rotation;
    }

    public void SetFollowTarget(BatCapsule target)
    {
        batFollower = target;
    }
}
