using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPlayer : MonoBehaviour
{
    public BeatLoop loop;
    private float musicLastTime = 0;
    public bool resetLoop = true;

    public float loopRatio { get {float result = BeatService.instance.time / (loop.stepCount * BeatService.instance.beatDuration); return result - Mathf.Floor(result);}}

    public System.Action<List<BeatConfig>> onBeat;

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
            if(loop.loopContent[i * loop.stepCount + beatIndex % loop.stepCount])
            {
                configs.Add(BeatService.instance.beats[i]);
            }
        }
        onBeat?.Invoke(configs);
    }
}
