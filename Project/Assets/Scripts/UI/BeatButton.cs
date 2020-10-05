using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatButton : MonoBehaviour
{
    public Image beatImage;
    public Image checkedImage;
    private Color checkedColor;
    public float fadeOutTime;
    public float fadeOutDuration = 0.5f;
    public Toggle toggle;
    public bool isDisabled;
    public GameObject disabledSprite;

    void Start()
    {
        
    }

    public void SetColor(Color color)
    {
        checkedImage.color = color;
        checkedColor = color;
    }

    void Update()
    {
        if(disabledSprite != null)
            disabledSprite.SetActive(isDisabled);
        if(fadeOutTime > 0)
        {
            fadeOutTime -= Time.deltaTime;
            Color color = new Color(1, 1, 1, 1);
            if(toggle.isOn)
                color = checkedColor;
            beatImage.color = new Color(color.r * 1.2f, color.g * 1.2f, color.b * 1.2f, fadeOutTime / fadeOutDuration);
        }
    }

    public void Flash()
    {
        fadeOutTime = fadeOutDuration;
    }
}
