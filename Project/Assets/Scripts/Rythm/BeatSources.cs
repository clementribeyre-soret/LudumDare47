using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSources : MonoBehaviour
{
    private Dictionary<BeatConfig, AudioSource> sources = new Dictionary<BeatConfig, AudioSource>();
    public AudioSource sourcePrefab;
    public BeatPlayer player;
    void Start()
    {
        for(int i=0; i<BeatService.instance.beats.Length; i++)
        {
            AudioSource source = Instantiate(sourcePrefab, transform);
            sources.Add(BeatService.instance.beats[i], source);
            source.clip = BeatService.instance.beats[i].sound;
        }
        player.onBeat += OnBeat;
    }

    private void OnDestroy()
    {
        player.onBeat -= OnBeat;

    }
    void OnBeat(int beatIndex, List<BeatConfig> configs)
    {
        foreach(BeatConfig config in configs)
        {
            sources[config].Play();
        }
    }
}
