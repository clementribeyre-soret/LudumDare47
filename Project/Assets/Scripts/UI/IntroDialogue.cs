using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    public System.Action onClosed;

    public void Close()
    {
        onClosed?.Invoke();
    }
}
