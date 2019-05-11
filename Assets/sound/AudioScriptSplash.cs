using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioScriptSplash : MonoBehaviour
{

    public AudioClip[] splashAudioClip;
    public AudioSource splashAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        splashAudioSource = GetComponent<AudioSource>();
        splashAudioSource.clip = splashAudioClip[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(!splashAudioSource.isPlaying)
        {
            splashAudioSource.clip = splashAudioClip[Random.Range(0, splashAudioClip.Length)];
        }
    }
}
