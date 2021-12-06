using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameController
{
    static int points = 0;
    static int hp = 3;

    public static void addPoint(int pts)
    {
        points += pts;
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + points;
    }
    public static void damage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Debug.Log("im ded");
        }
    }

}
