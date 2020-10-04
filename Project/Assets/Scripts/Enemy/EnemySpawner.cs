using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Ship shipPrefab;
    public EnemyWave[] waves;
    private List<Ship> spawnElements = new List<Ship>();
    private int aliveSpawnedCount;
    public float spacing = 1;

    private bool mustSpawnNextWave = false;

    
    void Start()
    {
        SpawnRandomWave();
    }

    void Update()
    {
        if(mustSpawnNextWave)
        {
            mustSpawnNextWave = false;
            SpawnRandomWave();
        }
    }

    void SpawnRandomWave()
    {
        int selectedWave = Random.Range(0, waves.Length);
        EnemyWave wave = waves[selectedWave];
        int toSpawnCount = wave.toSpawn.Length;
        for(int i=0; i<wave.toSpawn.Length; i++)
        {
            Ship spawned = Instantiate(shipPrefab, transform.position + transform.right * (i - toSpawnCount / 2), transform.rotation);
            spawned.config = wave.toSpawn[i];
            spawnElements.Add(spawned);
            spawned.onDeath += DecrSpawnedCount;
        }
    }

    void DecrSpawnedCount(Ship ship)
    {
        spawnElements.Remove(ship);
        if(spawnElements.Count == 0)
            mustSpawnNextWave = true;
    }
}
