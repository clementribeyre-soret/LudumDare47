using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource source;
    public float time { get { return source.time; } }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
