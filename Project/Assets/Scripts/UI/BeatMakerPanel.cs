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
    void Start()
    {
        if(player == null)
            player = GameState.instance.playerShipInstance.GetComponent<BeatPlayer>();
        titleText.text = BeatService.instance.beats[beatConfigIndex].name;
        knobText.text = "5";
        BeatService.instance.onBeat += OnBeat;
        for(int i=0; i<buttons.Length; i++)
        {
            buttons[i].SetColor(BeatService.instance.beats[beatConfigIndex].color);
            ValueToggle toggle = buttons[i].GetComponent<ValueToggle>();
            toggle.index = i + beatConfigIndex * buttons.Length;
            toggle.ForceChecked(player.loop.GetBeatValue(toggle.index % player.loop.stepCount, toggle.index / player.loop.stepCount));
            toggle.valueChanged += OnValueChanged;
        }
    }

    private void OnValueChanged(ValueToggle toggle)
    {
        player.loop.SetBeatValue(toggle.index % player.loop.stepCount, toggle.index / player.loop.stepCount, toggle.isChecked);
    }

    private void OnBeat(int index)
    {
        buttons[index % buttons.Length].Flash();
    }

    void Update()
    {
        
    }
}
