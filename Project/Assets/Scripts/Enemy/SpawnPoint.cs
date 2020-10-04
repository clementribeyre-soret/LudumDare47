using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyType
{
    Car1_Line, Car1_Zigzag, Car2, Boss
}

public class SpawnPoint : MonoBehaviour
{
    public static List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    public EnemyType[] allowedEnemyTypes;

    private void Awake()
    {
        spawnPoints.Add(this);
    }

    public static List<SpawnPoint> SpawnPointsForEnemy(EnemyType type)
    {
        List<SpawnPoint> result = new List<SpawnPoint>();
        foreach(SpawnPoint point in spawnPoints)
        {
            foreach(EnemyType enemyType in point.allowedEnemyTypes)
            {
                if(type == enemyType)
                {
                    result.Add(point);
                }
            }
        }
        return result;
    }
}