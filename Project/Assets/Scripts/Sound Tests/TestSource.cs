using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSource : MonoBehaviour
{
    public static TestSource instance;
    public AudioSource musicSource;
    public AudioSource beatSource;
    public AudioSource hihatSource;
    double bpm = 120;
    double stepCount = 8;
    double startOffset = 1;
    public float musicOffset = -0.01f;
    public float scheduleOffset = 1/30f;
    private double nextBeatTime;
    double startTime;
    int beatIndex = -1;
    private double nextMusicTime;
    private double musicLoopDuration;

    private struct BeatDelegate
    {
        System.Action beatDelegate;
        int beat;
    }

    private List<BeatDelegate> delegates = new List<BeatDelegate>();
    

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        startTime = AudioSettings.dspTime + startOffset;
        musicSource.PlayScheduled(startTime);
        nextBeatTime = startTime;
        int musicLoopBeatCount = Mathf.FloorToInt((float)(musicSource.clip.length / 60 * bpm));
        nextMusicTime = startTime + 60 / bpm * musicLoopBeatCount;
    }

    public int nextBeatIndex { get { return Mathf.FloorToInt((float)((AudioSettings.dspTime - startTime) / 60 * bpm));}}
    public int GetLoopBeatCount(float duration)
    {
        return Mathf.FloorToInt((float)(duration / 60 * bpm));
    }

    public double GetBeatTime(int beatIndex)
    {
        return startTime + beatIndex * 60 / bpm;
    }

    public double TimeToStep(int step)
    {
        return GetBeatTime(beatIndex) - AudioSettings.dspTime;
    }

    public void PlaySound(AudioSource source, int beatIndex)
    {
        source.PlayScheduled(startTime + + 60 / bpm * beatIndex);
    }

    void Update()
    {
        bool hasBeat = false;
        double currentBeatTime = nextBeatTime;
        if(nextBeatTime - AudioSettings.dspTime < scheduleOffset)
        {
            beatIndex++;
            nextBeatTime += 60.0 / bpm;
            hasBeat = true;
        }
        if(nextMusicTime - AudioSettings.dspTime < scheduleOffset)
        {
            musicSource.PlayScheduled(nextMusicTime);
            nextMusicTime += 60.0 / bpm;
        }
        if(hasBeat && beatIndex % 2 == 0)
        {
            beatSource.PlayScheduled(currentBeatTime);
        }
        
        if(hasBeat)
        {
            hihatSource.PlayScheduled(currentBeatTime);
        }
    }
}
