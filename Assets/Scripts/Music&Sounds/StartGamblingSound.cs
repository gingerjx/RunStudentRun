using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGamblingSound : MonoBehaviour
{
    
    public void onButtonClicked()
    {
        Button button = (Button)(GameObject.Find("StartButton").GetComponent<Button>());
        
        if (!GameController.soundMuted && button.GetComponentInChildren<Text>().text != "You used daily limit") button.GetComponent<AudioSource>().Play();
    }
}
