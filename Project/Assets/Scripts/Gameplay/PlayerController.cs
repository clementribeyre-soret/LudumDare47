using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Ship ship;
    
    void Start()
    {
        ship = GetComponentInParent<Ship>();
    }

    void Update()
    {
        if(GameState.instance.movementAllowed)
            ship.transform.position += speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime;
    }
}
