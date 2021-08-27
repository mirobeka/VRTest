using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RayInteractorHider : MonoBehaviour
{
    public InputActionReference enableRayAction = null;

    private LineRenderer lineInteractorRenderer = null;
    private XRInteractorLineVisual lineInteractorVisual = null;
    private XRRayInteractor lineInteractor = null;
    private GameObject lineInteractorReticle = null;
    private bool visible = true;

    void Awake(){
        lineInteractor = GetComponent<XRRayInteractor>();
        lineInteractorRenderer = GetComponent<LineRenderer>();
        lineInteractorVisual = GetComponent<XRInteractorLineVisual>();
        lineInteractorReticle = lineInteractorVisual.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        ToggleRay();
        enableRayAction.action.performed += ToggleRayAction;
        enableRayAction.action.canceled += ToggleRayAction;

    }

    private void ToggleRayAction(InputAction.CallbackContext ctx)
    {
        ToggleRay();
    }


    private void ToggleRay()
    {
        visible = !visible;
        lineInteractor.enabled = visible;
        lineInteractorRenderer.enabled = visible;
        lineInteractorVisual.enabled = visible;
        lineInteractorReticle.SetActive(visible);
    }



}
