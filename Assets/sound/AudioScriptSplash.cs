using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioScriptSplash : MonoBehaviour
{

    public AudioClip[] splashAudioClip;
    public AudioSource splashAudioSource;
    public int timer;
    private float splashTimer;

    // Start is called before the first frame update
    void Start()
    {
        splashAudioSource = GetComponent<AudioSource>();
        splashAudioSource.clip = splashAudioClip[0];
        splashTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        splashTimer -= Time.deltaTime;

        if(!splashAudioSource.isPlaying && splashTimer < 0)
        {
            splashAudioSource.clip = splashAudioClip[Random.Range(0, splashAudioClip.Length)];
            splashAudioSource.Play();
            splashTimer = timer;
        }
    }
}
