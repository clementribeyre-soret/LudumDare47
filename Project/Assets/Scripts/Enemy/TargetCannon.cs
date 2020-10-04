﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCannon : MonoBehaviour
{
    private Ship target;
    void Start()
    {
        target = GameState.instance.playerShipInstance;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.down, target.transform.position - transform.position, Vector3.forward));
    }
}