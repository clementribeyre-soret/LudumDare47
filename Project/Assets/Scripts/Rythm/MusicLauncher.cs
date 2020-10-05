using UnityEngine;

public class MusicLauncher : MonoBehaviour
{
    public bool playOnStart;
    public AudioClip music;
    private void Start()
    {
        if(playOnStart)
            PlayMusic();
    }
    
    public void PlayMusic()
    {
        BeatService.instance.PlayMusicImmediately(music);
    }
}