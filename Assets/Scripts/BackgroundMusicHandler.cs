using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicHandler : MonoBehaviour
{
    private AudioSource music;
    public static bool AdsNowPlaying = false;

    private void Start()
    {
        music = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        music.Play();
        if (AdsNowPlaying) {
            music.Pause();
            Debug.Log("music Stopped");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // mutowanie muzyki globalnie
        if (GameController.musicMuted == false)  music.volume = 1;
        else music.volume = 0;
    }
}
