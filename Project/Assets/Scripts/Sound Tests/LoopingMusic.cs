using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoopingMusic : MonoBehaviour
{
    private AudioSource source;
    private int startIndex;
    private int loopBeatCount;

    void Start()
    {
        source = GetComponent<AudioSource>();
        startIndex = TestSource.instance.nextBeatIndex;
        TestSource.instance.PlaySound(source, startIndex);
        loopBeatCount = TestSource.instance.GetLoopBeatCount(source.clip.length);
    }

    private void Update()
    {
    }
}