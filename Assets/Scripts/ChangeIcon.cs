using UnityEngine;
using UnityEngine.UI;

public class ChangeIcon : MonoBehaviour
{
    public Sprite unMutedSprite;
    public Sprite mutedSprite;
    public Image image;

    void Start()
    {
        if (image == GameObject.Find("MuteMusicImage").GetComponent<Image>())
        {
            image.sprite = GameController.musicMuted ? mutedSprite : unMutedSprite;
        }
        else if (image == GameObject.Find("MuteSoundImage").GetComponent<Image>())
        {
            image.sprite = GameController.soundMuted ? mutedSprite : unMutedSprite;
        }
    }

    void handleMusicAndSoundMute(bool muted)
    {
        if (image == GameObject.Find("MuteMusicImage").GetComponent<Image>())
        {
            GameController.musicMuted = muted;
        }
        else if (image == GameObject.Find("MuteSoundImage").GetComponent<Image>())
        {
            GameController.soundMuted = muted;
        }
    }

    public void ChangeButtonIcon()
    {
        var cmp = image.sprite == unMutedSprite;
        image.sprite = cmp ? mutedSprite : unMutedSprite;
        handleMusicAndSoundMute(cmp);
    }
}
