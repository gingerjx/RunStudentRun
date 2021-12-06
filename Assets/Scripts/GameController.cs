using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameController
{
    static int ects = 0;
    static int hp = 3;

    public static void addEcts(int pts)
    {
        ects += pts;
        GameObject.Find("Ects").GetComponent<Text>().text = "Ects: " + ects;
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
