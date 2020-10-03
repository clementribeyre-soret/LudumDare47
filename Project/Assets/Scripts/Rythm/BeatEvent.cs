using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatEvent : MonoBehaviour
{
    public BeatConfig config;
    public UnityEvent onBeat;

    private void Start()
    {
        BeatService.instance.onBeat += OnBeat;
    }

    private void OnDestroy()
    {
        BeatService.instance.onBeat -= OnBeat;
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
