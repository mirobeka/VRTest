using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiManager : MonoBehaviour
{

    public GameObject[] confettiCanons = null;
    public float pauseInBetween = 0.2f;

    public void Fire(){

        float cumulativeDelay = 0f;
        for (int i = 0; i < confettiCanons.Length; i += 1){
            Confetti confetti = confettiCanons[i].GetComponent<Confetti>();
            StartCoroutine( DelayedFire(cumulativeDelay, confetti) );
            cumulativeDelay += pauseInBetween;
        }
    }

    private IEnumerator DelayedFire(float delay, Confetti confetti){
        yield return new WaitForSeconds(delay);
        confetti.Play();
    }

}
