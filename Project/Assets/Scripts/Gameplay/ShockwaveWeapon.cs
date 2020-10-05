using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveWeapon : MonoBehaviour
{
    private Health health;
    public float damage = 1;
    public float range = 2;
    public float delay = 0.1f;

    private float shootDelay = 0;

    private void Start()
    {
        health = GetComponentInParent<Health>();
    }

    private void Update()
    {
        if(shootDelay > 0)
        {
            shootDelay -= Time.deltaTime;
            if(shootDelay <= 0)
            {
                Collider2D[] overlapColliders = Physics2D.OverlapCircleAll(transform.position, range);
                foreach(Collider2D c in overlapColliders)
                {
                    Health targetHealth = c.GetComponent<Health>();
                    if(targetHealth != null && health.team != targetHealth.team)
                    {
                        targetHealth.Damage(damage);
                    }
                }
            }
        }
    }

    public void Shoot()
    {
        if(GameState.instance.canLaunchProjectiles)
            shootDelay = delay;
    }
}
