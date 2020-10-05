using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource source;
    private float lastSourceTime;
    private float _time;
    public float time { get { return _time; } }
    public bool isPlaying = false;
    private bool sourcePlaying = false;
    private float pendingClipTime = 0;
    public float pendingClipDuration = 1;

    private AudioClip pendingClip;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void StartPlaying()
    {
        isPlaying = true;
        source.Play();
    }
    public void StopPlaying()
    {
        isPlaying = false;
    }

    void Update()
    {
        if(pendingClip != null)
        {
            pendingClipTime += Time.deltaTime;
            source.volume = 1 - pendingClipTime / pendingClipDuration;
            if(pendingClipTime > pendingClipDuration)
            {
                source.Stop();
                source.clip = pendingClip;
                source.Play();
                source.volume = 1;
                pendingClip = null;
                _time = 0;
            }
        }
        else
        {
            if(source.isPlaying)
            {
                if(!sourcePlaying)
                {
                    lastSourceTime = 0;
                    sourcePlaying = true;
                }
                if(source.time - lastSourceTime < 0)
                {
                    _time = 0;
                    lastSourceTime = 0;
                }
                _time += source.time - lastSourceTime;
                
                lastSourceTime = source.time;
            }
            else
            {
                _time += Time.deltaTime;
                sourcePlaying = false;
            }
        }
    }

    public void Play(AudioClip clip)
    {
        if(source.isPlaying)
        {
            pendingClip = clip;
            pendingClipTime = 0;
        }
        else
        {
            source.clip = clip;
            source.Play();

        }
    }

    public void PlayImmediately(AudioClip clip)
    {
        source.Stop();
        source.clip = clip;
        source.Play();
    }
}
