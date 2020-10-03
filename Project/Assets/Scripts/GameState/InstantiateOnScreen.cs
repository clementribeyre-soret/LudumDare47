using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnScreen : MonoBehaviour
{
    public Transform[] toInstantiate;
    public Transform parent;

    List<GameObject> instantiated = new List<GameObject>();

    public void Start()
    {
        GetComponent<Screen>().onScreenEnter += OnScreenEnter;
        GetComponent<Screen>().onScreenExit += OnScreenExit;
    }

    public void OnScreenEnter()
    {
        foreach(Transform prefab in toInstantiate)
            instantiated.Add(Instantiate(prefab, parent).gameObject);
    }

    public void OnScreenExit()
    {
        foreach(GameObject toDestroy in instantiated)
        {
            Destroy(toDestroy);
        }
        instantiated.Clear();
    }

}
