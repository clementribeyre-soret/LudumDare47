using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Ship ship;
    public Rect allowedArea;
    
    void Start()
    {
        ship = GetComponentInParent<Ship>();
    }

    void Update()
    {
        if(GameState.instance.movementAllowed)
            ship.transform.position += speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime;

        if(ship.transform.position.x < allowedArea.xMin)
            ship.transform.position = new Vector2(allowedArea.xMin, ship.transform.position.y);
        if(ship.transform.position.x > allowedArea.xMax)
            ship.transform.position = new Vector2(allowedArea.xMax, ship.transform.position.y);
        if(ship.transform.position.y < allowedArea.yMin)
            ship.transform.position = new Vector2(ship.transform.position.x, allowedArea.yMin);
        if(ship.transform.position.y > allowedArea.yMax)
            ship.transform.position = new Vector2(ship.transform.position.x, allowedArea.yMax);
    }
}
