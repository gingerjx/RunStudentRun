using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSavedDataShop : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.HasKey("KnowledgePoints"))
            GameObject.Find("KnowledgePoints").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("Highscore");
        else
            GameObject.Find("KnowledgePoints").GetComponent<Text>().text = "0";

        if (PlayerPrefs.HasKey("Coins"))
            GameObject.Find("Coins").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("Coins");
        else
            GameObject.Find("Coins").GetComponent<Text>().text = "0";
    }

}
