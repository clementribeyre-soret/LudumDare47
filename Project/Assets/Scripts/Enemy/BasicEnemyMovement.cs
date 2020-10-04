using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    public float velocity = 3;
    private Ship ship;

    void Start()
    {
        ship = GetComponentInParent<Ship>();
    }

    void Update()
    {
        ship.transform.position += ship.transform.up * velocity * Time.deltaTime;
    }
}
