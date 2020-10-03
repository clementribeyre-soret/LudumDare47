using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    public Transform prefab;
    
    public void SpawnChild()
    {
        Instantiate(prefab, transform);
    }

    public void SpawnWithParent(Transform parent)
    {
        Instantiate(prefab, transform.position, transform.rotation, parent);
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
