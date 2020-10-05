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
    private float endTimer = 0;
    public Animator animator;
    void Start()
    {
        text.text = textLines[0];
        index++;
    }

    private void Update()
    {
        if(endTimer > 0)
        {
            endTimer -= Time.deltaTime;
            if(endTimer <= 0)
                onDialogueEnd?.Invoke();
        }
    }
    public void Next()
    {
        if(index < textLines.Length)
        {
            text.text = textLines[index];
            index++;
        }
        else
        {
            endTimer = 1;
            animator.SetTrigger("Close");
        }
    }
}
