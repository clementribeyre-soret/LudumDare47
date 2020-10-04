using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public System.Action<Ship> onDeath;
    public BeatPlayer player;
    public ShipConfig config;
    
    void Start()
    {
        Instantiate(config.shipPrefab, transform);
        Instantiate(config.movementPatternPrefab, transform);
        player.loop = config.loops[Mathf.Min(GameState.instance.currentLevel, config.loops.Length - 1)];
    }

    private void OnDestroy()
    {
        onDeath?.Invoke(this);
    }

    void Update()
    {

    }
}
