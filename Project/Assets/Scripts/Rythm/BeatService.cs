using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatService : MonoBehaviour
{
    public static BeatService instance;
    private void OnEnable() { instance = this;}

    public BeatConfig[] beats;
    public int stepCount;
    public float bpm;
    private float time;
    private int beatIndex = 0;
    public Loop loop;
    private AudioSource[] sources;
    public AudioSource sourcePrefab;

    public float loopRatio { get {return (time + beatIndex * 60 / bpm) / (stepCount * 60 / bpm);}}

    public System.Action<List<BeatConfig>> onBeat;
    
    void Start()
    {
        loop.loopContent = new bool[stepCount * beats.Length];
        sources = new AudioSource[beats.Length];
        for(int i=0; i<beats.Length; i++)
        {
            sources[i] = Instantiate(sourcePrefab, transform);
            sources[i].clip = beats[i].sound;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > 60 / bpm)
        {
            beatIndex = (beatIndex + 1) % stepCount;
            time -= 60/bpm;
            List<BeatConfig> configs = new List<BeatConfig>();
            for(int i=0; i<beats.Length; i++)
            {
                if(loop.loopContent[i * stepCount + beatIndex])
                {
                    configs.Add(beats[i]);
                    sources[i].Play();
                }
            }
            onBeat?.Invoke(configs);

        }
    }
}
