using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatMaker : MonoBehaviour
{
    public ValueToggle buttonPrefab;
    public Transform instrumentTitlePanel;
    public Text instrumentTitlePrefab;

    public GridLayoutGroup gridLayout;
    private ValueToggle[] toggles;
    public BeatPlayer player;
    public string beatPlayerName;
    public BeatCursor cursor;

    void Start()
    {
        if(player == null)
            player = BeatPlayer.registered[beatPlayerName];
        cursor.player = player;
        int stepCount = player.loop.stepCount;
        BeatConfig[] beats = BeatService.instance.beats;
        gridLayout.constraintCount = stepCount;
        toggles = new ValueToggle[beats.Length * stepCount];
        for(int i=0; i<beats.Length * stepCount; i++)
        {
            ValueToggle toggle = Instantiate(buttonPrefab, gridLayout.transform);
            toggles[i] = toggle;
            toggle.index = i;
            toggle.ForceChecked(player.loop.loopContent[toggle.index]);
            toggle.valueChanged += OnValueChanged;
        }
        for(int i=0; i<beats.Length; i++)
        {
            Instantiate(instrumentTitlePrefab, instrumentTitlePanel).text = beats[i].name;
        }
    }

    private void OnValueChanged(ValueToggle toggle)
    {
        player.loop.loopContent[toggle.index] = toggle.isChecked;
    }

    void Update()
    {
        
    }
}
