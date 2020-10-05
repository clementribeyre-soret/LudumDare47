using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    private Ship ship;
    private Health health;

    private void Start()
    {
        ship = GetComponentInParent<Ship>();
        health = GetComponentInParent<Health>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Ship otherShip = other.GetComponentInParent<Ship>();
        if(otherShip != null && otherShip != ship)
        {
            other.GetComponentInParent<Health>().Kill();
            health.Damage(1);
        }
    }
}