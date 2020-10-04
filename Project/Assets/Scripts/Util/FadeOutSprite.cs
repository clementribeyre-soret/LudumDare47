using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeOutSprite : MonoBehaviour
{
    public float disappearDuration = 1;
    public float destroyDelay = 2;
    private float disappearTime;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        disappearTime += Time.deltaTime;
        spriteRenderer.color = new Color(1, 1, 1, 1 - disappearTime / disappearDuration);
        if(disappearTime > destroyDelay)
            Destroy(gameObject);
    }
}