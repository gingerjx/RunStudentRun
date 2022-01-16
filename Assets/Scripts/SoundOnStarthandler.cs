using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnStarthandler : MonoBehaviour
{
    private static string prevScene = "main";

    void Start()
    {
        if (!GameController.soundMuted && GameObject.Find("SkinsHandler")) {
            GameObject.Find("ButtonClickSound").GetComponent<AudioSource>().Play();
            prevScene = "shop";
        }
        else if (!GameController.soundMuted && GameObject.Find("LootBoxHandler")) {
            GameObject.Find("ButtonClickSound").GetComponent<AudioSource>().Play();
            prevScene = "lootBox";
        }
        else if (prevScene == "shop"){
            GameObject.Find("ButtonClickSound").GetComponent<AudioSource>().Play();
            prevScene = "main";
        }
    }
}
