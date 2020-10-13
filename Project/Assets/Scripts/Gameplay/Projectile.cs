using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public Team team;
    public float destroyAfter = 5;
    private float lifeTime;
    private static List<Projectile> projectiles = new List<Projectile>();
    public Transform explosionFXPrefab;

    private void Start()
    {
        projectiles.Add(this);
    }

    private void OnDestroy()
    {
        projectiles.Remove(this);
    }

    public static void DestroyAllProjectiles()
    {
        foreach(Projectile projectile in projectiles)
        {
            Destroy(projectile.gameObject);
        }
        projectiles.Clear();
    }

    public static void DestroyProjectiles(Team team)
    {
        List<Projectile> newProjectiles = new List<Projectile>();
        foreach(Projectile projectile in projectiles)
        {
            if(projectile.team == team)
                Destroy(projectile.gameObject);
            else newProjectiles.Add(projectile);
        }
        projectiles = new List<Projectile>();
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifeTime += Time.deltaTime;
        if(destroyAfter > 0 && lifeTime > destroyAfter)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if(health == null)
            health = other.GetComponentInParent<Health>();
        if(health != null && team != health.team)
        {
            PlayerHitbox playerHitbox = health.GetComponent<PlayerHitbox>();
            if(playerHitbox == null || !playerHitbox.isInvincible)
                health.Damage(damage);
            if(explosionFXPrefab != null)
            {
                Instantiate(explosionFXPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
