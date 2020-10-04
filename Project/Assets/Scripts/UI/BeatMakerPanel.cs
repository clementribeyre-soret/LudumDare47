using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatMakerPanel : MonoBehaviour
{
    public int beatConfigIndex;
    public Text titleText;
    public Text knobText;
    private BeatPlayer player;
    public BeatButton[] buttons;
    public string beatPlayerName;
    void Start()
    {
        if(player == null)
            player = BeatPlayer.registered[beatPlayerName];
        titleText.text = BeatService.instance.beats[beatConfigIndex].name;
        knobText.text = "5";
        BeatService.instance.onBeat += OnBeat;
        for(int i=0; i<buttons.Length; i++)
        {
            buttons[i].SetColor(BeatService.instance.beats[beatConfigIndex].color);
            ValueToggle toggle = buttons[i].GetComponent<ValueToggle>();
            toggle.index = i + beatConfigIndex * buttons.Length;
            toggle.ForceChecked(player.loop.loopContent[toggle.index]);
            toggle.valueChanged += OnValueChanged;
        }
    }

    private void OnValueChanged(ValueToggle toggle)
    {
        player.loop.loopContent[toggle.index] = toggle.isChecked;
    }

    private void OnBeat(int index)
    {
        buttons[index % buttons.Length].Flash();
    }

    void Update()
    {
        
    }
}
