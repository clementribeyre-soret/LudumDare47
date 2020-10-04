using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform shipRenderPrefab;

    void Start()
    {
        Instantiate(shipRenderPrefab, transform);
    }

    void Update()
    {
        
    }
}
