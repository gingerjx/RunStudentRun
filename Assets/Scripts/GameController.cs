using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameController
{
    const int SEMESTER_PASS = 4; // For debugging purposes, will be changed to 30

    static int semester = 1;
    static int ects = 0;
    static int hp = 3;

    public static void addEcts(int pts)
    {
        ects += pts;
        if (ects >= SEMESTER_PASS)
        {
            ects -= SEMESTER_PASS;
            semester += 1;
        }
        
        GameObject.Find("Ects").GetComponent<Text>().text = "Ects: " + ects;
        GameObject.Find("Semester").GetComponent<Text>().text = "Sem: " + semester;
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
