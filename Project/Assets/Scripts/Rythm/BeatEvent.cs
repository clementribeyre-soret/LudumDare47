using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatEvent : MonoBehaviour
{
    public BeatConfig config;
    public UnityEvent onBeat;

    public BeatPlayer beatPlayer;

    private void Start()
    {
        beatPlayer.onBeat += OnBeat;
    }

    private void OnDestroy()
    {
        beatPlayer.onBeat -= OnBeat;
    }
    
    private void OnBeat(List<BeatConfig> beats)
    {
        foreach(BeatConfig beat in beats)
        {
            if(beat == config)
            {
                onBeat.Invoke();
            }
        }
    }
}
