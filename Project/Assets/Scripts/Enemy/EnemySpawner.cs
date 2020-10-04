using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnerSlot
{
    public Transform spawnPos;
    public ShipSpawnPosition slotId;
}

public class EnemySpawner : MonoBehaviour
{
    public Ship shipPrefab;
    public SpawnerSlot[] slots;
    private List<Ship> spawnElements = new List<Ship>();
    private int aliveSpawnedCount;
    public float spacing = 1;

    private bool mustSpawnNextWave = false;

    private float spawnTime = 0;
    private List<ShipSpawnConfig> toSpawn = new List<ShipSpawnConfig>();

    public System.Action onWaveCleared;

    
    void Start()
    {
        
    }

    void Update()
    {
        spawnTime += Time.deltaTime;
        List<int> toRemove = new List<int>();
        for(int i=0; i<toSpawn.Count; i++)
        {
            ShipSpawnConfig spawnConfig = toSpawn[i];
            if(spawnTime >= spawnConfig.delay)
            {
                Transform slot = GetSpawnerSlot(spawnConfig.position);
                Ship spawned = Instantiate(shipPrefab, slot.position + slot.right * spawnConfig.offset, slot.rotation);
                spawned.config = spawnConfig.ship;
                spawnElements.Add(spawned);
                spawned.onDeath += DecrSpawnedCount;
                toRemove.Add(i);
            }
        }
        for(int i = toRemove.Count - 1; i >= 0; i--)
        {
            toSpawn.RemoveAt(i);
        }
    }

    Transform GetSpawnerSlot(ShipSpawnPosition index)
    {
        foreach(SpawnerSlot slot in slots)
        {
            if(slot.slotId == index)
            {
                return slot.spawnPos;
            }
        }
        return null;
    }

    public void SpawnWave(EnemyWave wave)
    {
        spawnTime = 0;
        int toSpawnCount = wave.toSpawn.Length;
        for(int i=0; i<wave.toSpawn.Length; i++)
        {
            toSpawn.Add(wave.toSpawn[i]);
        }
    }

    void DecrSpawnedCount(Ship ship)
    {
        spawnElements.Remove(ship);
        if(spawnElements.Count == 0 && toSpawn.Count == 0)
        {
            onWaveCleared?.Invoke();
        }
    }
}
