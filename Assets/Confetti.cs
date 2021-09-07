using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public AudioSource pop = null;
    public AudioSource debris = null;
    private ParticleSystem ps = null;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        // vypni vizual pre confetti
        GameObject visual = transform.Find("Visual").gameObject;
        visual.SetActive(false);

    }

    public void Play()
    {
        pop.Play();
        ps.Play();
        debris.Play();
    }
}
