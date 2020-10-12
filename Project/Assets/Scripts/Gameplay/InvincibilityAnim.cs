using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityAnim : MonoBehaviour
{
    private PlayerHitbox hitbox;
    private new SpriteRenderer renderer;
    private float animTime;
    public float animDuration = 1;
    private Color color = Color.white;
    void Start()
    {
        hitbox = GetComponentInParent<PlayerHitbox>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hitbox.isInvincible)
        {
            animTime += Time.deltaTime;
        }
        else
        {
            animTime = 0;
        }
        color = renderer.color;
        color.a = (1.5f + Mathf.Cos(animTime / animDuration * 2 * Mathf.PI)) / 2.5f;
        renderer.color = color;
    }
}
