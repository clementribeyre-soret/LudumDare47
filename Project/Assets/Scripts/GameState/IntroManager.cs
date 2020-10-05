using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public Transform carPrefab;
    private Transform car;
    public Transform carStartPosition;
    public Transform carTargetPosition;
    public float carAnimDuration = 3;
    private float time;
    public ScreenTransition nextLevel;
    public DialoguePanel dialoguePrefab;
    private bool popupClosed = false;

    IEnumerator AnimCoroutine()
    {
        car = Instantiate(carPrefab, carStartPosition.position, carStartPosition.rotation);
        while(time < carAnimDuration)
        {
            time += Time.deltaTime;
            car.transform.position = Vector3.Lerp(carStartPosition.position, carTargetPosition.position, time / carAnimDuration);
            yield return null;
        }
        
        DialoguePanel panel = Instantiate(dialoguePrefab);
        panel.onDialogueEnd += OnPopupClosed;
        while(!popupClosed)
            yield return null;
        Destroy(panel.gameObject);
        nextLevel.StartTransition();
    }

    private void OnPopupClosed()
    {
        popupClosed = true;
    }

    private void Start()
    {
        if(GameState.instance.skipIntro)
        {
            nextLevel.StartTransition();
        }
        else
            StartCoroutine(AnimCoroutine());
    }

    void Update()
    {

    }
}
