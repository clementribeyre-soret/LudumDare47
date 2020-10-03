using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public Transform cameraPosition;
    public float cameraSize;

    public System.Action onScreenEnter;
    public System.Action onScreenExit;

    public void Start()
    {
        CameraController.instance.screens.Add(gameObject.name, this);
    }
}
