using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPlayer : MonoBehaviour
{
    public BeatLoop loop;
    private float musicLastTime = 0;
    public bool resetLoop = true;

    public float loopRatio { get {double result = BeatService.instance.time / (loop.stepCount * BeatService.instance.beatDuration); return (float)result - Mathf.Floor((float)result);}}

    public System.Action<int, List<BeatConfig>> onBeat;

    public static Dictionary<string, BeatPlayer> registered = new Dictionary<string, BeatPlayer>();

    private void Awake()
    {
        registered[gameObject.name] = this;
    }

    void Start()
    {
        //if(resetLoop)
        //    loop.loopContent = new bool[loop.stepCount * BeatService.instance.beats.Length];

        BeatService.instance.onBeat += OnBeat;
    }

    void OnDestroy()
    {
        BeatService.instance.onBeat -= OnBeat;
    }

    void OnBeat(int beatIndex)
    {
        List<BeatConfig> configs = new List<BeatConfig>();
        for(int i=0; i<BeatService.instance.beats.Length; i++)
        {
            if(loop.GetBeatValue(beatIndex % loop.stepCount, i))
            {
                configs.Add(BeatService.instance.beats[i]);
            }
        }
        onBeat?.Invoke(beatIndex % loop.stepCount, configs);
    }
}
