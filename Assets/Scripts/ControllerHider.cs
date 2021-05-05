using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(PhysicsPoser))]
[RequireComponent(typeof(XRDirectInteractor))]
public class ControllerHider : MonoBehaviour
{
    public GameObject controllerObject = null;

    private PhysicsPoser physicsPoser = null;
    private XRDirectInteractor interactor = null;

    private void Awake()
    {
        physicsPoser = GetComponent<PhysicsPoser>();
        interactor = GetComponent<XRDirectInteractor>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(Hide);
        interactor.selectExited.AddListener(Show);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(Hide);
        interactor.selectExited.RemoveListener(Show);
    }

    private void Hide(SelectEnterEventArgs actionEvent)
    {
        controllerObject.SetActive(false);
    }

    private void Show(SelectExitEventArgs actionEvent)
    {
        StartCoroutine(WaitForRange());
    }

    private IEnumerator WaitForRange()
    {
        yield return new WaitWhile(physicsPoser.WithinPhysicsRange);
        controllerObject.SetActive(true);
    }
}
