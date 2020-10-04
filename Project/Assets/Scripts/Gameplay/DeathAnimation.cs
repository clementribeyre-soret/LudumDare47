using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public Transform deathAnimPrefab;
    void Start()
    {
        GetComponentInParent<Health>().onDeathDelegate += OnDeath;        
    }


    public void OnDeath(Health health)
    {

    }
}
