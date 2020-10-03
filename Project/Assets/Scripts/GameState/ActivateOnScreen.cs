using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnScreen : MonoBehaviour
{
    public GameObject[] toActivate;
    public Transform parent;

    public void Start()
    {
        GetComponent<Screen>().onScreenEnter += OnScreenEnter;
        GetComponent<Screen>().onScreenExit += OnScreenExit;
    }

    public void OnScreenEnter()
    {
        foreach(GameObject element in toActivate)
            element.SetActive(true);
    }

    public void OnScreenExit()
    {
        foreach(GameObject element in toActivate)
            element.SetActive(false);
    }

}
