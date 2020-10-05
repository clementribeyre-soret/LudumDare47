using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlashOnDamage : MonoBehaviour
{
    public Color color;
    private SpriteRenderer spriteRenderer;
    private Health health;
    private float intensity;
    public float intensityDecreaseSpeed = 2;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponentInParent<Health>();
        health.onDamageDelegate += OnDamage;
    }

    public void OnDamage(Health health)
    {
        intensity = 1;
    }

    private void Update()
    {
        if(intensity > 0)
        {
            intensity -= Time.deltaTime;
            spriteRenderer.color = Color.Lerp(Color.white, color, intensity);
        }
    }
}
