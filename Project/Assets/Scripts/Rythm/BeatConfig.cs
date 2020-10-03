using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BeatConfig : ScriptableObject
{
    public new string name;
    public AudioClip sound;
    public Sprite icon;
}
