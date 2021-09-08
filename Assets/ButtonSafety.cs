using UnityEngine;
using UnityEngine.Events;

public class ButtonSafety : MonoBehaviour
{
    public float deadZone = 20f;
    public UnityEvent onOpened, onClosed = null;

    private HingeJoint joint = null;
    private float maxAngle = 0f;
    private bool isOpenned = false;
    

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        maxAngle = joint.limits.max;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = joint.angle;
        if (angle >= maxAngle && !isOpenned){
            isOpenned = true;
            onOpened.Invoke();
        }
        
        if (angle < maxAngle-deadZone && isOpenned ){
            isOpenned = false;
            onClosed.Invoke();
        }
    }
}
