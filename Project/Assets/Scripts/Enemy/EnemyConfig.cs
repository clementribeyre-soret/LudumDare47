using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyConfig : ScriptableObject
{
    public EnemyType type;
    public GameObject prefab;
    public BeatLoop loop;
}
