using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Loop
{
    public bool[] loopContent;
}

public class BeatLoop : MonoBehaviour
{
    public BeatConfig[] beats;
    public int stepCount;
    public float bpm;
    private float time;
    private int beatIndex = 0;
    public Loop loop;
    private AudioSource[] sources;
    public AudioSource sourcePrefab;
    
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
            for(int i=0; i<beats.Length; i++)
            {
                if(loop.loopContent[i * stepCount + beatIndex])
                {
                    sources[i].Play();
                }
            }

        }
    }
}
