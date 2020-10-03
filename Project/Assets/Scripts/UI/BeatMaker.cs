using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatMaker : MonoBehaviour
{
    public BeatLoop loop;
    public ValueToggle buttonPrefab;

    public GridLayoutGroup gridLayout;
    private ValueToggle[] toggles;

    void Start()
    {
        gridLayout.constraintCount = loop.stepCount;
        toggles = new ValueToggle[loop.beats.Length * loop.stepCount];
        for(int i=0; i<loop.beats.Length * loop.stepCount; i++)
        {
            ValueToggle toggle = Instantiate(buttonPrefab, gridLayout.transform);
            toggles[i] = toggle;
            toggle.index = i;
            toggle.valueChanged += OnValueChanged;
        }
    }

    private void OnValueChanged(ValueToggle toggle)
    {
        loop.loop.loopContent[toggle.index] = toggle.isChecked;
    }

    void Update()
    {
        
    }
}
