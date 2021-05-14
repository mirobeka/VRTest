using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableColliderOnGrab : MonoBehaviour
{
    private XRGrabInteractable interactable = null;
    private CapsuleCollider batCollider = null;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        batCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (interactable.isSelected)
        {
            batCollider.enabled = false;
        }
        else
        {
            batCollider.enabled = true;

        }

    }

//    private void OnEnable()
//    {
//        interactable.selectEntered.AddListener(DisableCollider);
//        interactable.selectExited.AddListener(EnableCollider);
//    }
//
//    private void OnDisable()
//    {
//        interactable.selectEntered.RemoveListener(DisableCollider);
//        interactable.selectExited.RemoveListener(EnableCollider);
//    }
//
//    private void EnableCollider(SelectEnterEventArgs actionEvent)
//    {
//        batCollider.enabled = true;
//    }
//
//    private void DisableCollider(SelectEnterEventArgs actionEvent)
//    {
//        batCollider.enabled = false;
//    }
}
