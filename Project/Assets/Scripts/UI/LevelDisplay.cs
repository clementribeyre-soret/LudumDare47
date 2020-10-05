using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public Sprite[] sprites;
    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        img.sprite = sprites[(GameState.instance.currentLevel)];
    }
}
