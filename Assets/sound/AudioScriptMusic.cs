using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioScriptMusic : MonoBehaviour
{

    public AudioClip musicAudioClip;
    public AudioSource musicAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.clip = musicAudioClip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
