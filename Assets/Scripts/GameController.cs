using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameController
{
    const int SEMESTER_PASS = 4; // For debugging purposes, will be changed to 30
    const int BACHELOR_SEM = 1; // For debugging purposes, will be changed to 7
    const int MASTER_SEM = 2; // For debugging purposes, will be changed to 10
    const int PHD_SEM = 3; // For debugging purposes, will be changed to 20
    const string BACHELOR_NAME = "B.S.E.";
    const string MASTER_NAME = "M.S.";
    const string PHD_NAME = "Ed.D.";
    const int MAX_ENERGY = 100;

    static int semester = 1;
    static int ects = 0;
    static int energy = 98;

    public static void addEcts(int pts)
    {
        ects += pts;
        if (ects >= SEMESTER_PASS)
        {
            ects -= SEMESTER_PASS;
            semester += 1;

            if (semester > BACHELOR_SEM && semester <= MASTER_SEM)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + BACHELOR_NAME;
            }
            else if (semester > MASTER_SEM && semester <= PHD_SEM)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + MASTER_NAME;
            }
            else
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + PHD_NAME;
            }
        }
        
        GameObject.Find("Ects").GetComponent<Text>().text = "Ects: " + ects;
        GameObject.Find("Semester").GetComponent<Text>().text = "Sem: " + semester;
    }

    public static void addEnergy(int pts)
    {
        energy += pts;
        if (energy > MAX_ENERGY)
            energy = MAX_ENERGY;

        GameObject.Find("Energy").GetComponent<Text>().text = "Energy: " + energy;

        if (energy <= 0)
        {
            Debug.Log("im ded");
        }
    }

}
