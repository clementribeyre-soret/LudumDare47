using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipSpawnPosition
{
    Top,
    Right,
    Left,
} 

[System.Serializable]
public struct ShipSpawnConfig
{
    public ShipConfig ship;
    public ShipSpawnPosition position;
    public float delay;
    public float offset;
}

[CreateAssetMenu]
public class EnemyWave : ScriptableObject
{
    public ShipSpawnConfig[] toSpawn;
}
