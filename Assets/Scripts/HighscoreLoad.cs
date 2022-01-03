using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreLoad : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.HasKey("Highscore"))
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        else
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: 0";
    }

}
