using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDisplay : MonoBehaviour
{
    public BeatStepDisplay stepPrefab;
    public BeatPlayer player;
    public string beatPlayerName;
    public BeatCursor cursor;

    void Start()
    {
        if(player == null)
            player = BeatPlayer.registered[beatPlayerName];
        cursor.player = player;
        int stepCount = player.loop.stepCount;
        for(int i=0; i<stepCount; i++)
        {
            BeatStepDisplay stepDisplay = Instantiate(stepPrefab, transform);
            int beatConfig = 0;
            for(int j=0; j<BeatService.instance.beats.Length; j++)
            {
                if(player.loop.loopContent[i * stepCount + j])
                {
                    beatConfig++;
                }
            }
            stepDisplay.beatConfig = beatConfig;
        }
    }

    void Update()
    {
        
    }
}
