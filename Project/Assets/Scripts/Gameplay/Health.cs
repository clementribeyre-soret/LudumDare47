using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum Team
{
    Player, Enemy
}

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public float currentHealth;
    public UnityEvent onDeath;
    public System.Action<Health> onDeathDelegate;
    public Team team;

    public UnityEvent onDamage;
    public System.Action<Health> onDamageDelegate;
    
    private void Start()
    {
        currentHealth = (float)maxHealth;
    }

    public void Damage(float damage)
    {
        onDamage.Invoke();
        onDamageDelegate?.Invoke(this);
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            onDeathDelegate?.Invoke(this);
            onDeath.Invoke();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
