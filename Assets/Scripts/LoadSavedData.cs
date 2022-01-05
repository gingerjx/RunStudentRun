using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSavedData : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.HasKey("Highscore"))
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        else
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: 0";

        if (PlayerPrefs.HasKey("Coins"))
            GameObject.Find("Coins").GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("Coins");
        else
            GameObject.Find("Coins").GetComponent<Text>().text = "Coins: 0";
    }

}
