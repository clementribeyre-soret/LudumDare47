using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenTransitionActions : MonoBehaviour
{
    public UnityEvent enterEvent;
    public UnityEvent exitEvent;
    public void Start()
    {
        GetComponent<Screen>().onScreenEnter += OnScreenEnter;
        GetComponent<Screen>().onScreenExit += OnScreenExit;
    }

    private void OnScreenEnter()
    {
        enterEvent.Invoke();
    }

    private void OnScreenExit()
    {
        exitEvent.Invoke();
    }
}
