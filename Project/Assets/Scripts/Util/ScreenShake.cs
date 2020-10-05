using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    public float trauma;
    public float traumaDecreaseRate = 1;
    public float traumaPower = 2;
    public float rollIntensity = 1;
    public float moveIntensity = 1;
    
    private void Awake()
    {
        instance = this;
    }
    public void Shake()
    {
        trauma = 1;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, rollIntensity * Mathf.Pow(trauma, traumaPower) * Random.Range(-1, 1));
        transform.localPosition = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * moveIntensity * Mathf.Pow(trauma, traumaPower);
        if(trauma > 0)
            trauma -= traumaDecreaseRate * Time.deltaTime;
        if(trauma < 0)
            trauma = 0;
    }
}
