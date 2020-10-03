using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCursor : MonoBehaviour
{
    public float ratio = 0;
    public RectTransform target;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        Vector2 min = target.rect.min;
        Vector2 max = target.rect.max;

        ratio = BeatService.instance.loopRatio;
        
        rectTransform.anchoredPosition = new Vector2(target.position.x + min.x + (max.x - min.x) * ratio, target.position.y);
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, target.rect.size.y);
    }
}
