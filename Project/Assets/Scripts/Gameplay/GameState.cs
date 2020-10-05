using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public Ship playerShipInstance;

    public bool movementAllowed;
    public Ship playerShipPrefab;
    public int currentLevel = 0;
    public bool canLaunchProjectiles = false;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        currentLevel = 0;
    }

    public void SpawnPlayer()
    {
        playerShipInstance = Instantiate(playerShipPrefab);
    }

    public void RemovePlayer()
    {
        Destroy(playerShipInstance.gameObject);
    }

    public void BlockMovement()
    {
        movementAllowed = false;
    }

    public void ReleaseMovement()
    {
        movementAllowed = true;
    }

    public void ClearLevel()
    {
        Ship.DestroyAllShips();
        Projectile.DestroyAllProjectiles();
    }

    public void AllowProjectiles()
    {
        canLaunchProjectiles = true;
    }

    public void PreventProjectiles()
    {
        canLaunchProjectiles = false;
    }
}
