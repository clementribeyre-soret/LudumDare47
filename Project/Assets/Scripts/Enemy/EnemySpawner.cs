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

    
    void Start()
    {
        SpawnRandomWave();
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
            spawned.GetComponent<Health>().onDeathDelegate += DecrSpawnedCount;
        }
    }

    void DecrSpawnedCount(Health health)
    {
        spawnElements.Remove(health.GetComponent<Ship>());
        if(spawnElements.Count == 0)
            SpawnRandomWave();
    }
}
