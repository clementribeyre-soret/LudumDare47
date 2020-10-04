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

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifeTime += Time.deltaTime;
        if(lifeTime > destroyAfter)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if(health == null)
            health = other.GetComponentInParent<Health>();
        if(health != null && team != health.team)
        {
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
