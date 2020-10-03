using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatStepDisplay : MonoBehaviour
{
    public int beatConfig;
    public int maxBeatConfig = 5;
    public Color emptyColor;
    public Color fullColor;
    public Image image;
    void Start()
    {
        image.color = Color.Lerp(emptyColor, fullColor, (float)beatConfig / (float)maxBeatConfig);
    }

    void Update()
    {
        
    }
}
