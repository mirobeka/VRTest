using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestFrameRate : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        float newRate = 90f;
        if (Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(newRate))
        {
            Time.fixedDeltaTime = 1f / newRate;
            Time.maximumDeltaTime = 1f / newRate;
        }
    }
}
