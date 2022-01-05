using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIcon : MonoBehaviour
{
    public Sprite unMutedSprite;
    public Sprite mutedSprite;
    public Button button;

    void Start()
    {
        if (button == GameObject.Find("MuteMusic").GetComponent<Button>())
        {
            if (GameController.musicMuted) button.image.sprite = mutedSprite;
            else button.image.sprite = unMutedSprite;
        }
        else if (button == GameObject.Find("MuteSound").GetComponent<Button>())
        {
            if (GameController.soundMuted) button.image.sprite = mutedSprite;
            else button.image.sprite = unMutedSprite;
        }
    }

    void handleMusicAndSoundMute(bool muted)
    {
        if (button == GameObject.Find("MuteMusic").GetComponent<Button>())
        {
            Debug.Log("Music muted = " + muted);
            GameController.musicMuted = muted;
            Debug.Log("Music c muted = " + GameController.musicMuted);
        }
        else if (button == GameObject.Find("MuteSound").GetComponent<Button>())
        {
            Debug.Log("Sound muted = " + muted);
            GameController.soundMuted = muted;
            Debug.Log("Sound c muted = " + GameController.soundMuted);
        }
    }

    public void ChangeButtonIcon()
    {
        if (button.image.sprite == unMutedSprite)
        { 
            button.image.sprite = mutedSprite;
            handleMusicAndSoundMute(true);
        }
        else if (button.image.sprite == mutedSprite) 
        {
            button.image.sprite = unMutedSprite;
            handleMusicAndSoundMute(false);
        } 
    }
}
