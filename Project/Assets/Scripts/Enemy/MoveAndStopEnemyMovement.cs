using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndStopEnemyMovement : MonoBehaviour
{
    public float velocity = 3;
    public float distanceBeforeStop = 10;
    private float travelledDistance = 0;
    Ship ship;

    void Start()
    {
        ship = GetComponentInParent<Ship>();
    }

    void Update()
    {
        if(travelledDistance < distanceBeforeStop)
        {
            ship.transform.position += ship.transform.up * velocity * Time.deltaTime;
            travelledDistance += Time.deltaTime * velocity;

        }

    }
}
