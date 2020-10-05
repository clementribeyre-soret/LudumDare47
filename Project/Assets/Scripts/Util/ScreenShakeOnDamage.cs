using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeOnDamage : MonoBehaviour
{
    private Health health;
    void Start()
    {
        health = GetComponentInParent<Health>();
        health.onDamageDelegate += Shake;
    }

    private void Shake(Health health)
    {
        ScreenShake.instance.Shake();
    }

    private void OnDestroy()
    {
        health.onDamageDelegate -= Shake;
    }

    void Update()
    {
        
    }
}
