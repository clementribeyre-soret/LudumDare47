using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer deathAnimPrefab;
    public SpriteRenderer shipSprite;

    void Start()
    {
        GetComponentInParent<Health>().onDeathDelegate += OnDeath;        
    }


    public void OnDeath(Health health)
    {
        SpriteRenderer spawned = Instantiate(deathAnimPrefab, transform.position, transform.rotation);
        spawned.sprite = shipSprite.sprite;
        spawned.transform.localScale = shipSprite.transform.lossyScale;
    }
}
