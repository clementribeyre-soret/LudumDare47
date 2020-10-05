using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = "Level " + (GameState.instance.currentLevel + 1);
    }
}
