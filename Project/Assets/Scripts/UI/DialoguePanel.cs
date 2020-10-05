using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public string[] textLines;
    public Text text;
    private int index = 0;
    public System.Action onDialogueEnd;
    void Start()
    {
        text.text = textLines[0];
        index++;
    }
    public void Next()
    {
        if(index < textLines.Length)
        {
            text.text = textLines[index];
            index++;
        }
        else onDialogueEnd?.Invoke();
    }
}
