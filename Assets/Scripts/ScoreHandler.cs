using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private static float timer = 0.0f;
    void Update()
    {
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled == true)
        {
            timer += Time.deltaTime;
        }
        
    }

    public static void resetTimer()
    {
        timer = 0.0f;
    }

    public static int GetScore(int semester, int currentTitle)
    {
        int seconds = (int)timer;

        return semester * seconds * currentTitle;
    }
}
