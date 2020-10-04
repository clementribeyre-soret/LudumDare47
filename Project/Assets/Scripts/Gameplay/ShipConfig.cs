using UnityEngine;

[CreateAssetMenu]
public class ShipConfig : ScriptableObject
{
    public Transform shipPrefab;
    public Transform movementPatternPrefab;
    public BeatLoop loop;
}