using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform cameraPosTransform;
    private void Awake() { instance = this;}
    public Screen currentScreen;
    public Screen targetScreen;
    public float transitionDuration;
    public float transitionTime;
    public Camera mainCamera;

    public Dictionary<string, Screen> screens = new Dictionary<string, Screen>();

    public void TransitionToScreen(Screen screen, float transitionDuration)
    {
        targetScreen = screen;
        this.transitionDuration = transitionDuration;
        this.transitionTime = 0;
        currentScreen.onScreenExit?.Invoke();
    }
    
    public void TransitionToScreen(string screenName, float transitionDuration)
    {
        targetScreen = screens[screenName];
        this.transitionDuration = transitionDuration;
        this.transitionTime = 0;
        currentScreen.onScreenExit?.Invoke();
    }

    private void Start()
    {
    }

private bool started = false;
    private void Update()
    {
        if(!started)
        {
            cameraPosTransform.position = currentScreen.transform.position;
            mainCamera.orthographicSize = currentScreen.cameraSize;
            currentScreen.onScreenEnter?.Invoke();
            started = true;
        }
        if(targetScreen != null && transitionTime < transitionDuration)
        {
            transitionTime += Time.deltaTime;
            if(transitionTime >= transitionDuration)
            {
                transitionTime = transitionDuration;
                currentScreen = targetScreen;
                currentScreen.onScreenEnter?.Invoke();
            }
            Vector3 startPos = targetScreen.cameraPosition.position;
            float startSize = targetScreen.cameraSize;
            if(currentScreen != null)
            {
                startPos = currentScreen.cameraPosition.position;
                startSize = currentScreen.cameraSize;
            }
            cameraPosTransform.position = Vector3.Lerp(startPos, targetScreen.transform.position, transitionTime / transitionDuration);
            mainCamera.orthographicSize = startSize + (targetScreen.cameraSize - startSize) * (transitionTime / transitionDuration);
        }
    }
}