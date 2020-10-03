using System;
using System.Collections;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public float duration;
    public string screen;

    public void StartTransition()
    {
        CameraController.instance.TransitionToScreen(screen, duration);
    }
}