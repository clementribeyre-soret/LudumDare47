using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipIntroToggle : MonoBehaviour
{
    Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = GameState.instance.skipIntro;
    }


    // Update is called once per frame
    void Update()
    {
        GameState.instance.skipIntro = toggle.isOn;
    }
}
