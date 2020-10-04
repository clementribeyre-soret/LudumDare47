using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] waves;
    private List<GameObject> spawnElements = new List<GameObject>();
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
            GameObject spawned = Instantiate(wave.toSpawn[i], transform.position + transform.right * (i - toSpawnCount / 2), wave.toSpawn[i].rotation).gameObject;
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
