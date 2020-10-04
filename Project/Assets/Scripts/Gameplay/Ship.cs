using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public Transform shipContent;
    
    void Start()
    {
        Instantiate(shipContent, transform);
    }

    void Update()
    {
        
    }
}
