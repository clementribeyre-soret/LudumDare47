using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] waves;
    private List<GameObject> spawnElements = new List<GameObject>();
    private int aliveSpawnedCount;
    public float spacing = 1;
    public Transform[] spawnPoints;

    
    void Start()
    {
        SpawnRandomWave();
    }

    void SpawnRandomWave()
    {
        int selectedWave = Random.Range(0, waves.Length);
        EnemyWave wave = waves[selectedWave];
        int toSpawnCount = wave.toSpawn.Length;
        List<Transform> availableSpawnPoints = new List<Transform>();
        foreach(Transform spawnPoint in spawnPoints)
            availableSpawnPoints.Add(spawnPoint);
        for(int i=0; i<wave.toSpawn.Length; i++)
        {
            int spawnIndex = Random.Range(0, availableSpawnPoints.Count);
            GameObject spawned = Instantiate(wave.toSpawn[i], availableSpawnPoints[spawnIndex].position, availableSpawnPoints[spawnIndex].rotation * wave.toSpawn[i].rotation).gameObject;
            availableSpawnPoints.RemoveAt(spawnIndex);
            spawnElements.Add(spawned);
            spawned.GetComponent<Health>().onDeathDelegate += DecrSpawnedCount;
            Debug.Log(spawned);
        }
    }

    void DecrSpawnedCount(Health health)
    {
        spawnElements.Remove(health.gameObject);
        if(spawnElements.Count == 0)
            SpawnRandomWave();
    }
}
