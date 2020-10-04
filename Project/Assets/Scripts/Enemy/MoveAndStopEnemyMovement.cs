using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndStopEnemyMovement : MonoBehaviour
{
    public float velocity = 3;
    public float distanceBeforeStop = 10;
    private float travelledDistance = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(travelledDistance < distanceBeforeStop)
        {
            transform.position += transform.up * velocity * Time.deltaTime;
            travelledDistance += Time.deltaTime * velocity;

        }

    }
}
