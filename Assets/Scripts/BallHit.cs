using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BallHit : MonoBehaviour
{
    public AudioSource weakSwingSound = null;
    public AudioSource mediumSwingSound = null;
    public AudioSource hardSwingSound = null;
    public float soundDelay = 2f;

    private bool canPlaySounds = true;

    private Rigidbody rb = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator WaitUntilNextSound()
    {
        yield return new WaitForSeconds(soundDelay);
        canPlaySounds = true;
    }

    void PlayHitSound(float velocity){
        if (velocity > 2 && velocity <= 5){
            weakSwingSound.Play();
        }else if( velocity > 5 && velocity <= 10){
            mediumSwingSound.Play();
        }else if( velocity > 10){
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
            }
        }
    }
}
