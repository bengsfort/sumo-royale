using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioScriptCollision : MonoBehaviour
{
    public int startingPitch = 5;
    public AudioClip collisionAudioClip;
    public AudioSource collisionAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        collisionAudioSource = GetComponent<AudioSource>();
        collisionAudioSource.clip = collisionAudioClip;

        collisionAudioSource.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionAudioSource.pitch = Random.Range(0.5f, 1.5f);
        collisionAudioSource.Play();
    }
}
