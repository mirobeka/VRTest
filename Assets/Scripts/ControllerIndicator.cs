using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerIndicator : MonoBehaviour
{
    [SerializeField] public InputActionReference positionAction = null;
    [SerializeField] public InputActionReference rotationAction = null;
    [SerializeField] public GameObject hand = null;
    [SerializeField] public float showDistance = 0.25f;

    private Material material = null;
    private Color color = Color.white;
    private Vector3 targetPosition = Vector3.zero;
    private Quaternion targetRotation = Quaternion.identity;
    private float currentDistance = 0.0f;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        color = material.GetColor("_Color");
    }

    private void Update()
    {
        SetTargetPositionAndRotation();
        CalculateDistance();
        FadeColor();
        SetIndicatorPositionAndRotation();

    }

    private void SetIndicatorPositionAndRotation()
    {
        // move hand indicator to match real controller position
        transform.localPosition = targetPosition;
        transform.localRotation = targetRotation;
    }

    private void SetTargetPositionAndRotation()
    {
        targetPosition = positionAction.action.ReadValue<Vector3>();
        targetRotation = rotationAction.action.ReadValue<Quaternion>();
    }

    private void CalculateDistance()
    {
        currentDistance = Vector3.Distance(hand.transform.localPosition, targetPosition);
    }

    private void FadeColor()
    {
        color.a = CalculateAlpha(currentDistance);
        material.SetColor("_Color", color);
    }

    private float CalculateAlpha(float distance)
    {
        return Mathf.Clamp01((distance - showDistance) * 10f);
    }
}
