using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnParticle()
    {
        particleSystem.Play();
    }

    public void PlaySoundEffect()
    {
        audioSource.Play();
       AudioClip clip = audioSource.clip;
    }
}
