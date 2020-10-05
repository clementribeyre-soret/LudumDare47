using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    private EnemySpawner spawner;
    public LevelConfig[] levels;
    int waveCursor = 0;
    public Transform levelDisplayPrefab;
    private Transform levelDisplayInstance;
    public float startDelay = 3;
    private float startTime = 0;

    public UnityEvent onVictory;

    void Start()
    {
        spawner = GetComponent<EnemySpawner>();
        spawner.onWaveCleared += OnWaveCleared;
        GotoNextLevel();
    }

    void Update()
    {
        if(startTime < startDelay)
        {
            startTime += Time.deltaTime;
            if(startTime >= startDelay)
            {
                Destroy(levelDisplayInstance.gameObject);
                spawner.SpawnWave(levels[GameState.instance.currentLevel].waves[waveCursor]);
            }
        }
    }

    private void OnWaveCleared()
    {
        waveCursor++;
        if(waveCursor >= levels[GameState.instance.currentLevel].waves.Length)
        {
            GameState.instance.currentLevel++;
            if(GameState.instance.currentLevel >= levels.Length)
            {
                onVictory.Invoke();
            }
            else
            {
                waveCursor = 0;
                GotoNextLevel();
            }
        }
        else
        {
            spawner.SpawnWave(levels[GameState.instance.currentLevel].waves[waveCursor]);
        }
    }

    public void GotoNextLevel()
    {
        startTime = 0;
        levelDisplayInstance = Instantiate(levelDisplayPrefab);
    }
}
