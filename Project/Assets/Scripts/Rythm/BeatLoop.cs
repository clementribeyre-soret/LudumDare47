using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BeatLoop : ScriptableObject
{
    public int stepCount;
    public bool[] kick = new bool[8];
    public bool[] crash = new bool[8];
    public bool[] snare = new bool[8];
    public bool[] ride = new bool[8];

    public bool GetBeatValue(int beat, int instrument)
    {
        switch(instrument)
        {
            case 0:
                return kick[beat];
            case 1:
                return crash[beat];
            case 2:
                return snare[beat];
            case 3:
                return ride[beat];
        }
        return false;
    }

    public void SetBeatValue(int beat, int instrument, bool value)
    {
        switch(instrument)
        {
            case 0:
                kick[beat] = value;
                break;
            case 1:
                crash[beat] = value;
                break;
            case 2:
                snare[beat] = value;
                break;
            case 3:
                ride[beat] = value;
                break;
        }
    }


}
