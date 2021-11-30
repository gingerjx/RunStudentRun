using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    static int points = 0;
    static int hp = 3;

    public static void addPoint()
    {
        points += 1;
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
