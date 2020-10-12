using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioScheduler : MonoBehaviour
{
    public AudioClip startMusicClip;
    public static AudioScheduler instance;
    public AudioSource musicSource;

    public int bpm = 240;
    public int barCount = 4;
    public int musicStartBeat = 0;

    private void Awake()
    {
        instance = this;
    }

    public double beatDuration => 60.0 / bpm;
    public int currentBeat => Mathf.FloorToInt((float)(AudioSettings.dspTime / beatDuration));

    public int currentBar => currentBeat / barCount;

    public double beatStartTime(int beatIndex)
    {
        return beatDuration * beatIndex;
    }

    public int beatCount(double duration)
    {
        return Mathf.FloorToInt((float)(duration / beatDuration));
    }

    public void ScheduleMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicStartBeat = currentBeat;
        musicStartBeat += (barCount - (currentBeat + 1) % barCount);
        musicSource.PlayScheduled(beatStartTime(musicStartBeat));
    }

    private void Start()
    {
        ScheduleMusic(startMusicClip);
    }

    private void Update()
    {
        int musicBeatCount = beatCount(musicSource.clip.length);
        if(AudioSettings.dspTime > beatStartTime(musicStartBeat + musicBeatCount) - 0.01f)
        {
            musicStartBeat += musicBeatCount;
            musicSource.PlayScheduled(beatStartTime(musicStartBeat));
        }
    }
}