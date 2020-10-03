using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Projectile prefab;
    private Health health;

    private void Start()
    {
        health = GetComponentInParent<Health>();
    }
    
    public void SpawnChild()
    {
        Projectile spawned = Instantiate(prefab, transform);
        spawned.team = health.team;
    }

    public void SpawnWithParent(Transform parent)
    {
        Projectile spawned = Instantiate(prefab, transform.position, transform.rotation, parent);
        spawned.team = health.team;
    }

    public void Spawn()
    {
        Projectile spawned = Instantiate(prefab, transform.position, transform.rotation);
        spawned.team = health.team;
    }
}
