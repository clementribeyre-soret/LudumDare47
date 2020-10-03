using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDisplay : MonoBehaviour
{
    public BeatStepDisplay stepPrefab;

    void Start()
    {
        int stepCount = BeatService.instance.stepCount;
        for(int i=0; i<stepCount; i++)
        {
            BeatStepDisplay stepDisplay = Instantiate(stepPrefab, transform);
            int beatConfig = 0;
            for(int j=0; j<BeatService.instance.beats.Length; j++)
            {
                if(BeatService.instance.loop.loopContent[i * stepCount + j])
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
