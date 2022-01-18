using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public void onButtonClicked()
    {
        if (!GameController.soundMuted) GameObject.Find("ButtonClickSound").GetComponent<AudioSource>().Play();
    }
}
