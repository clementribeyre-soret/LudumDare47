﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatEvent : MonoBehaviour
{
    public BeatConfig config;
    public UnityEvent onSelectedBeat;
    public UnityEvent onBeat;
    public UnityEvent onBar;
    public UnityEvent onStrongBeat;

    public BeatPlayer beatPlayer;

    private void Start()
    {
        if(beatPlayer == null)
            beatPlayer = GetComponentInParent<BeatPlayer>();
        beatPlayer.onBeat += OnBeat;
    }

    private void OnDestroy()
    {
        beatPlayer.onBeat -= OnBeat;
    }
    
    private void OnBeat(int beatIndex, List<BeatConfig> beats)
    {
        onBeat.Invoke();
        if(beatIndex == 0)
            onBar.Invoke();
        if(beatIndex % 2 == 0)
            onStrongBeat.Invoke();
        if(beatIndex % 2 == 0)
            onStrongBeat.Invoke();
        foreach(BeatConfig beat in beats)
        {
            if(beat == config)
            {
                onSelectedBeat.Invoke();
            }
        }
    }
}
