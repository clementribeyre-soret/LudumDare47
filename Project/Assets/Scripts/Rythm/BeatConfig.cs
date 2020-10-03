using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BeatConfig : ScriptableObject
{
    public string name;
    public AudioClip sound;
    public Sprite icon;
}
