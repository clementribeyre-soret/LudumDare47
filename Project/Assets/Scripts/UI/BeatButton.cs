﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatButton : MonoBehaviour
{
    public Image beatImage;
    public Image checkedImage;
    public float fadeOutTime;
    public float fadeOutDuration = 0.5f;

    void Start()
    {
        
    }

    public void SetColor(Color color)
    {
        checkedImage.color = color;
    }

    void Update()
    {
        if(fadeOutTime > 0)
        {
            fadeOutTime -= Time.deltaTime;
            beatImage.color = new Color(1, 1, 1, fadeOutTime / fadeOutDuration);
        }
    }

    public void Flash()
    {
        fadeOutTime = fadeOutDuration;
    }
}