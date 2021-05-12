using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestFrameRate : MonoBehaviour
{
    public float refreshRate = 90f;
    // Start is called before the first frame update
    void Awake()
    {
        if (Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(refreshRate))
        {
            Time.fixedDeltaTime = 1f / refreshRate;
            Time.maximumDeltaTime = 1f / refreshRate;
        }
    }
}
