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
    private float currentHealth;
    public UnityEvent onDeath;
    public System.Action<Health> onDeathDelegate;
    public Team team;
    
    private void Start()
    {
        currentHealth = (float)maxHealth;
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
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
