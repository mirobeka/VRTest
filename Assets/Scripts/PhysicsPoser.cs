using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsPoser : MonoBehaviour
{
    // Values
    public float physicsRange = 0.1f;
    public LayerMask physicsMask = 0;

    [Range(0, 1)] public float slowDownVelocity = 0.75f;
    [Range(0, 1)] public float slowDownAngularVelocity = 0.75f;

    [Range(0, 100)] public float maxPositionChange = 75.0f;
    [Range(0, 100)] public float maxRotationChange = 75.0f;

    // Action based shit
    public InputActionReference positionAction = null;
    public InputActionReference rotationAction = null;

    // References
    public Transform xrRigTransform = null;
    private Rigidbody rigidBody = null;
    private XRBaseInteractor interactor = null;

    // Runtime
    private Vector3 targetPosition = Vector3.zero;
    private Quaternion targetRotation = Quaternion.identity;

    private void Awake()
    {
        // Get the stuff
        rigidBody = GetComponent<Rigidbody>();
        interactor = GetComponent<XRBaseInteractor>();
    }

    private void Start()
    {
        // As soon as we start, move to the hand
        MoveUsingTransform();
        RotateUsingTransform();
    }

    private void Update()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        targetPosition = positionAction.action.ReadValue<Vector3>();
    }

    private void UpdateRotation()
    {
        targetRotation = rotationAction.action.ReadValue<Quaternion>();
    }


    private void FixedUpdate()
    {
        // Move via transform if we're holding an object, or not within physics range
        if (IsHoldingObject() || !WithinPhysicsRange())
        {
            MoveUsingTransform();
            RotateUsingTransform();
        }

        // Else move using physics
        else
        {
            MoveUsingPhysics();
            RotateUsingPhysics();
        }

        // update position via transform after teleport
    }

    public bool IsHoldingObject()
    {
        return interactor.selectTarget;
    }

    public bool WithinPhysicsRange()
    {
        return Physics.CheckSphere(transform.position, physicsRange, physicsMask, QueryTriggerInteraction.Ignore);
    }

    private void MoveUsingPhysics()
    {
        // Prevents overshooting
        rigidBody.velocity *= slowDownVelocity;

        // Get target velocity
        Vector3 velocity = FindNewVelocity();

        // Check if it's valid
        if (IsValidVelocity(velocity.x))
        {
            // Figure out the max we can move, then move via velocity
            float maxChange = maxPositionChange * Time.deltaTime;
            rigidBody.velocity = Vector3.MoveTowards(rigidBody.velocity, velocity, maxChange);
        }

    }

    private Vector3 FindNewVelocity()
    {
        // target position, je  pozicia lokalna
        // rigid body je pozicia globalna
        // potrebovali by sme teda najprv prepocitat


        // position of rigid body operates only in world space. That's a problem when controllers
        // are in local space of xr Rig. First we need to transform position to local space of
        // xr rig 
        Vector3 localRigidBodyPosition = xrRigTransform.InverseTransformPoint(rigidBody.position);
        Vector3 difference = targetPosition - localRigidBodyPosition;
        return difference / Time.deltaTime;
    }

    private void RotateUsingPhysics()
    {
        // Prevents overshooting
        rigidBody.angularVelocity *= slowDownAngularVelocity;

        // Get target velocity
        Vector3 angularVelocity = FindNewAngularVelocity();

        // Check if it's valid
        if (IsValidVelocity(angularVelocity.x))
        {
            // Figure out the max we can rotate, then move via velocity
            float maxChange = maxRotationChange * Time.deltaTime;
            rigidBody.angularVelocity = Vector3.MoveTowards(rigidBody.angularVelocity, angularVelocity, maxChange);
        }

    }

    private Vector3 FindNewAngularVelocity()
    {
        // Figure out the difference in rotation
        Quaternion difference = targetRotation * Quaternion.Inverse(rigidBody.rotation);
        difference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

        // Do the weird thing to account for have a range of -180 to 180
        if (angleInDegrees > 180)
        {  
            angleInDegrees = -360;
        }

        // Figure out the difference we can move this frame
        return (rotationAxis * angleInDegrees * Mathf.Deg2Rad) / Time.deltaTime;
    }

    private bool IsValidVelocity(float value)
    {
        // Is it an actual number, or is a broken number?
        return !float.IsNaN(value) && !float.IsInfinity(value);
    }

    private void MoveUsingTransform()
    {
        // Prevents jitter
        rigidBody.velocity = Vector3.zero;
        transform.localPosition = targetPosition;
    }

    private void RotateUsingTransform()
    {
        // Prevents jitter
        rigidBody.angularVelocity = Vector3.zero;
        transform.localRotation = targetRotation;
    }

    private void OnDrawGizmos()
    {
        // Show the range at which the physics takeover
        Gizmos.DrawWireSphere(transform.position, physicsRange);
    }

    private void OnValidate()
    {
        // Just in case
        if (TryGetComponent(out Rigidbody rigidBody))
            rigidBody.useGravity = false;
    }
}
