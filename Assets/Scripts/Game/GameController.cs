using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class GameController
{
    const int SEMESTER_PASS = 30; // For debugging purposes, will be changed to 30
    const int BACHELOR_SEM = 7; // For debugging purposes, will be changed to 7
    const int MASTER_SEM = 10; // For debugging purposes, will be changed to 10
    const int PHD_SEM = 20; // For debugging purposes, will be changed to 20
    const int PROF_SEM = 40; // For debugging purposes, will be changed to 40
    const string BACHELOR_NAME = "B.S.E.";
    const string MASTER_NAME = "M.S.";
    const string PHD_NAME = "Ed.D.";
    const string PROF_NAME = "Prof.";
    const int MAX_ENERGY = 100;

    static int semester = 1;
    static int ects = 0;
    static int energy = 100;
    static int currentTitle = 0;

    static bool isPaused = false;
    
    public static bool musicMuted = false;
    public static bool soundMuted = false;

    public static void addEcts(int pts)
    {
        ects += pts;
        if (ects >= SEMESTER_PASS)
        {
            ects = 0;
            semester += 1;
            Debug.Log("semester " + semester);

            if (semester > BACHELOR_SEM && semester <= MASTER_SEM)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + BACHELOR_NAME;
                currentTitle = 2;
            }
            else if (semester > MASTER_SEM && semester <= PHD_SEM)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + MASTER_NAME;
                currentTitle = 3;
            }
            else if (semester > PHD_SEM && semester <= PROF_SEM)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + PHD_NAME;
                currentTitle = 4;
            }
            else if (semester > PROF_SEM)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: " + PROF_NAME;
                currentTitle = 5;
            }
            else
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Title: None";
            }
        }
        
        GameObject.Find("Ects").GetComponent<Text>().text = "Ects: " + ects;
        GameObject.Find("Semester").GetComponent<Text>().text = "Sem: " + semester;
    }

    public static void retry()
    {
        energy = MAX_ENERGY;
        ects = 0;
        currentTitle = 0;
        ScoreHandler.resetTimer();
    }

    public static void pauseGame()
    {
        if(isPaused)
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().UnPause();
            GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Pause();
            GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = true;
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public static void continueGame()
    {
        GameObject.Find("LoseScreen").GetComponent<Canvas>().enabled = false;
        GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = true;
        addEnergy(MAX_ENERGY);
    }
    public static void addEnergy(int pts)
    {
        energy += pts;
        energy = Mathf.Clamp(energy, 0, MAX_ENERGY);

        GameObject.Find("Energy").GetComponent<Text>().text = "Energy: " + energy;
        GameObject.Find("EnergyBarInner").GetComponent<Image>().fillAmount = Mathf.Clamp((float)energy/(float)MAX_ENERGY,0,1f);

        if (energy <= 0)
        {
            deadScreen();
        }
    }

    public static void decreaseEnergy(int pts)
    {
        if (EquipmentHandler.IsInsuranceBoostActive()) return;
        energy -= pts;

        GameObject.Find("Energy").GetComponent<Text>().text = "Energy: " + energy;
        GameObject.Find("EnergyBarInner").GetComponent<Image>().fillAmount = Mathf.Clamp((float)energy / (float)MAX_ENERGY, 0, 1f);

        if (energy <= 0)
        {
            deadScreen();
        }
    }

    public static void deadScreen()
    {
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Pause();
        GameObject.Find("LoseScreen").GetComponent<Canvas>().enabled = true;
        GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
        //GameObject.Find("Info").GetComponent<Text>().text ="Score: " + ScoreHandler.GetScore(semester, currentTitle);

        if (PlayerPrefs.HasKey("Highscore"))
        {                
            if (PlayerPrefs.GetInt("Highscore") < ScoreHandler.GetScore(semester, currentTitle))
                PlayerPrefs.SetInt("Highscore", ScoreHandler.GetScore(semester, currentTitle));
        }
        else
            PlayerPrefs.SetInt("Highscore", ScoreHandler.GetScore(semester, currentTitle));

        int coins = 0;
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        PlayerPrefs.SetInt("Coins", coins + (ScoreHandler.GetScore(semester, currentTitle)/10));



        ScoreHandler.resetTimer();

        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }


}