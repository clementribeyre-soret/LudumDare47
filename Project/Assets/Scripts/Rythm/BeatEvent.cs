using System.Collections;
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
    public UnityEvent onWeakBeat;

    public BeatPlayer beatPlayer;

    private void Start()
    {
        if(beatPlayer == null)
            beatPlayer = GetComponentInParent<BeatPlayer>();
        if(beatPlayer == null && GameState.instance.playerShipInstance != null)
            beatPlayer = GameState.instance.playerShipInstance.GetComponent<BeatPlayer>();
        if(beatPlayer != null)
            beatPlayer.onBeat += OnBeat;
    }

    private void OnDestroy()
    {
        if(beatPlayer != null)
            beatPlayer.onBeat -= OnBeat;
    }
    
    private void OnBeat(int beatIndex, List<BeatConfig> beats)
    {
        onBeat.Invoke();
        if(beatIndex == 0)
            onBar.Invoke();
        if(beatIndex % 2 == 0)
            onStrongBeat.Invoke();
        else onWeakBeat.Invoke();
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
