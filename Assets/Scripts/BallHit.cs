using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class BallHit : MonoBehaviour
{
    public float soundDelay = 2f;
    public AudioSource weakSwingSound = null;
    public AudioSource mediumSwingSound = null;
    public AudioSource hardSwingSound = null;
    public GameObject spankEffectPrefab = null;

    private float minVelocity = 2f; 
    private float midVelocity = 5f;
    private float maxVelocity = 10f;

    private bool canPlaySounds = true;
    private GameObject swingLabel = null;

    private Rigidbody rb = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        swingLabel = GameObject.Find("SwingForce/Force");
    }

    private IEnumerator WaitUntilNextSound()
    {
        yield return new WaitForSeconds(soundDelay);
        canPlaySounds = true;
    }

    void UpdateSwingForce(float velocity)
    {
        if(swingLabel != null)
        {
            TextMesh label = swingLabel.GetComponent<TextMesh>();
            label.text = String.Format("{0}", velocity);
        }

    }

    void SpankEffect(float velocity){
        if(velocity >= midVelocity){
            Instantiate(spankEffectPrefab, transform.position, Quaternion.identity);
        }
    }

    void PlayHitSound(float velocity)
    {
        if (velocity > minVelocity && velocity <= midVelocity){
            weakSwingSound.Play();
        }else if( velocity > midVelocity && velocity <= maxVelocity){
            mediumSwingSound.Play();
        }else if( velocity > maxVelocity){
            hardSwingSound.Play();
        }
        canPlaySounds = false;
        StartCoroutine(WaitUntilNextSound());
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bat")
        {
            if( !rb.isKinematic && canPlaySounds){
                float velocity = col.relativeVelocity.magnitude;
                PlayHitSound(velocity);
                UpdateSwingForce(velocity);
                SpankEffect(velocity);
            }
        }
    }
}
