using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningCannon : MonoBehaviour
{
    public float rotationSpeed = 10;
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime) * transform.rotation;
    }
}
