using System;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class AudioTimeDisplay : MonoBehaviour
{
    public AudioSource source;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        
    }

    private void Update()
    {
        text.text = "" + TestSource.instance.nextBeatIndex;
    }
}