using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatService : MonoBehaviour
{
    public static BeatService instance;
    private void OnEnable() { instance = this;}

    public BeatConfig[] beats;
    public float bpm;
    private float _time;
    public float time { get { return _time + beatIndex * 60/bpm;}}
    public float beatDuration { get { return 60/bpm; }}
    private int beatIndex = 0;
    private AudioSource[] sources;
    public AudioSource sourcePrefab;

    public MusicPlayer musicPlayer;
    private float musicLastTime = 0;

    public System.Action<int> onBeat;
    
    void Start()
    {
    }

    void Update()
    {
        float musicTime = musicPlayer.time;
        _time += musicTime - musicLastTime;
        musicLastTime = musicTime;
        if(_time > 60 / bpm)
        {
            beatIndex = beatIndex + 1;
            _time -= 60/bpm;
            onBeat?.Invoke(beatIndex);

        }
    }
}
