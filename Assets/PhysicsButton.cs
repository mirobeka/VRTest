using UnityEngine.Events;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    public UnityEvent onPressed, onReleased = null;
    public Material lightOnMaterial = null;

    private Material originalMaterial = null;
    private GameObject clicker = null;
    private bool lightOn = false;
    private bool isPressed = false;
    private Vector3 startPos = Vector3.zero;
    private ConfigurableJoint joint = null;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        clicker = transform.Find("Clicker").gameObject;
        originalMaterial = clicker.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if( ! isPressed && GetValue() + threshold >= 1 )
            Pressed();
        
        if( isPressed && GetValue() - threshold <= 0 )
            Released();
    }

    private float GetValue(){
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone){
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed(){
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released(){
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

    public void ToggleLight(){
        lightOn = !lightOn;

        if (lightOnMaterial == null)
            return;

        if (lightOn){
            clicker.GetComponent<MeshRenderer>().material = lightOnMaterial;
        }else{
            clicker.GetComponent<MeshRenderer>().material = originalMaterial;
        }
    }
}
