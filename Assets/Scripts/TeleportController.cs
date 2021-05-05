using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    public InputActionReference teleportAction = null;

    private XRRayInteractor rayInteractor = null;
    private XRInteractorLineVisual rayVisual = null;



    void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        rayVisual = GetComponent<XRInteractorLineVisual>();
    }

    void Start()
    {
        TeleportCancel();
        // set callbacks
        teleportAction.action.performed += TeleportModeActivate;
        teleportAction.action.canceled += TeleportModeCancel;
    }
    
    private void TeleportActive()
    {
        rayInteractor.enabled = true;
        rayVisual.enabled = true;
    }

    private void TeleportCancel()
    {
        rayInteractor.enabled = false;
        rayVisual.enabled = false;
    }

    private void TeleportModeActivate(InputAction.CallbackContext ctx)
    {
        TeleportActive();
    }

    private void TeleportModeCancel(InputAction.CallbackContext ctx)
    {
        StartCoroutine(DelayedTeleportCancel());
    }

    private IEnumerator DelayedTeleportCancel()
    {
        yield return new WaitForSeconds(.1f);
        TeleportCancel();
    }



}
