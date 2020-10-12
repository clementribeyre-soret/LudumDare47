﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatService : MonoBehaviour
{
    public static BeatService instance;
    private void OnEnable() { instance = this;}

    public BeatConfig[] beats;
    public float bpm;
    private double _time;
    public double time { get { return _time + beatIndex * 60/bpm;}}
    public float beatDuration { get { return 60/bpm; }}
    private int beatIndex = 0;
    private AudioSource[] sources;
    public AudioSource sourcePrefab;
    private double musicLastTime = 0;

    public System.Action<int> onBeat;
    
    void Start()
    {
    }

    void Update()
    {
        double musicTime = AudioSettings.dspTime;
        if(musicLastTime > musicTime)
        {
            musicLastTime = 0;
            _time = 0;
            beatIndex = 0;
        }
        _time += musicTime - musicLastTime;
        musicLastTime = musicTime;
        while(_time > 60 / bpm)
        {
            beatIndex = beatIndex + 1;
            _time -= 60/bpm;
            onBeat?.Invoke(beatIndex - AudioScheduler.instance.musicStartBeat);

        }
    }
}
