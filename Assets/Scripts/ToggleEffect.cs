using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ToggleEffect : MonoBehaviour
{
    public GameObject collisionObj;
    public GameObject colliderObj;
    public ParticleSystem fireParticle;
    public ParticleSystem extinguishParticle;
    public AudioSource audioSource;
    public AudioSource burst;

    private void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        fireParticle.Stop();
        if (extinguishParticle != null)
            extinguishParticle.Play();
        //Destroy(collisionObj);
        burst.Play();
        audioSource.Play();
        collisionObj.SetActive(false);
    }
}
