using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public GameObject[] hearts;
    public Health health;
    void Start()
    {
        if(health == null)
            health = GameState.instance.playerShipInstance.GetComponent<Health>();
        
    }

    void Update()
    {
        for(int i=0; i<hearts.Length; i++)
        {
            hearts[i].SetActive(i < health.currentHealth);
        }
    }
}
