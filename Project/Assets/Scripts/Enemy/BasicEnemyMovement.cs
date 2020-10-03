using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    public float velocity = 3;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.up * velocity * Time.deltaTime;
    }
}
