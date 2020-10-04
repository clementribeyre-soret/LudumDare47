using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public BeatPlayer player;
    public ShipConfig config;
    
    void Start()
    {
        Instantiate(config.shipPrefab, transform);
        Instantiate(config.movementPatternPrefab, transform);
        player.loop = config.loop;
    }

    void Update()
    {

    }
}
