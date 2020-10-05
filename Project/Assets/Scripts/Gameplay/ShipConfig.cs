using UnityEngine;

[CreateAssetMenu]
public class ShipConfig : ScriptableObject
{
    public int health = 5;
    public Transform shipPrefab;
    public Transform movementPatternPrefab;
    public BeatLoop[] loops;
}