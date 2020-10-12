using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    private Ship ship;
    private Health health;
    public float invincibilityDuration = 2;
    private float invincibilityTime = 0;

    public bool isInvincible => invincibilityTime > 0;

    private void Start()
    {
        ship = GetComponentInParent<Ship>();
        health = GetComponentInParent<Health>();
        health.onDamageDelegate += OnDamage;
    }

    private void OnDamage(Health health)
    {
        invincibilityTime = invincibilityDuration;
    }

    private void Update()
    {
        if(invincibilityTime > 0)
            invincibilityTime -= Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(invincibilityTime > 0)
            return;
        Ship otherShip = other.GetComponentInParent<Ship>();
        if(otherShip != null && otherShip != ship)
        {
            other.GetComponentInParent<Health>().Kill();
            health.Damage(1);
            invincibilityTime = invincibilityDuration;
        }
    }
}