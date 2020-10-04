using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public bool movementAllowed;

    private void Awake()
    {
        instance = this;
    }

    public void BlockMovement()
    {
        movementAllowed = false;
    }

    public void ReleaseMovement()
    {
        movementAllowed = true;
    }
}
