using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private static List<Ship> ships = new List<Ship>();
    public System.Action<Ship> onDeath;
    public BeatPlayer player;
    public ShipConfig config;
    
    void Start()
    {
        Instantiate(config.shipPrefab, transform);
        Instantiate(config.movementPatternPrefab, transform);
        player.loop = config.loops[Mathf.Min(GameState.instance.currentLevel, config.loops.Length - 1)];
        ships.Add(this);
    }

    private void OnDestroy()
    {
        onDeath?.Invoke(this);
        ships.Remove(this);
    }

    public static void DestroyAllShips()
    {
        foreach(Ship ship in ships)
        {
            Destroy(ship.gameObject);
        }
        ships.Clear();
    }

    void Update()
    {

    }
}
