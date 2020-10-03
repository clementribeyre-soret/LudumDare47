using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ValueToggle : MonoBehaviour
{
    public int index;
    public bool isChecked;

    private Toggle toggle;

    public System.Action<ValueToggle> valueChanged;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate {
                SetChecked(toggle);
        });
    }

    public void SetChecked(bool isChecked)
    {
        this.isChecked = isChecked;
        valueChanged?.Invoke(this);
    }
}
