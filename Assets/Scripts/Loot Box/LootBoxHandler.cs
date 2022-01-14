using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LootBoxHandler : MonoBehaviour
{
    private RewardDraw drawScript;
    private AdPlayer adPlayer;
    private AdsController adsController;

    private Image lootbox;
    private Image resultBG;
    private Button startButton;

    public float minimum = 0.3f;
    public float maximum = 1f;
    public float cyclesPerSecond = 2.0f;
    public float acceleration = 1.01f;

    private float a;
    private bool increasing = true;
    private bool blink = false;
    private string todayDate;

    Color color;    

    void Start() {
        drawScript = GameObject.Find("RewardDrawHandler").GetComponent<RewardDraw>();
        adPlayer = GameObject.Find("AdPlayer").GetComponent<AdPlayer>();
        adsController = GameObject.Find("AdController").GetComponent<AdsController>();
        adsController.InitializeAds();

        lootbox = GameObject.Find("Lootbox").GetComponent<Image>();
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        resultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        hideResult();

        todayDate = System.DateTime.Now.ToShortDateString();
        color = lootbox.color;
        a = maximum;
        
        if (startedToday() && addWatchedToday()) {
            setDailyLimitDoneButton();
        } else if (startedToday()) {
            setWatchAdButton();
        } else {
            setStartButton();
        }
    }

    void Update() {
        if (blink) {
            doBlink();
        }
    }

    private void doBlink() {
        float t = Time.deltaTime;
        if (a >= maximum) increasing = false;
        if (a <= minimum) increasing = true;
        a = increasing ? a += t * cyclesPerSecond * 2 : a -= t * cyclesPerSecond;
        color.a = a;
        lootbox.color = color;
        cyclesPerSecond *= acceleration;
    }

    public void startLootBox() {
        if (blink == true)
            return;

        if (!startedToday()) {
            PlayerPrefs.SetInt(todayDate, 1);
            blink = true;
            setWatchAdButton();
            hideResult();
            drawCallback(2);
        } else if (!addWatchedToday()) {
            adPlayer.PlayRewardedAdWithCallback();
            PlayerPrefs.SetInt("add" + todayDate, 1);
            setDailyLimitDoneButton();
        }
    }

    public void drawCallback(int sec) {
        Invoke("draw", sec);
    }

    public void draw() {
        blink = false;
        cyclesPerSecond = 2.0f;
        color.a = 255;
        lootbox.color = color;

        KeyValuePair<string, int> result = drawScript.draw();
        addReward(result.Key, result.Value);
        showResult("You won" + (result.Key.Contains("skin") ? "" : " " +  result.Value) + " " + result.Key + "!");
    }

    private void showResult(string result) {
        resultBG.enabled = true;
        resultBG.GetComponentInChildren<Text>().text = result;
        Invoke("hideResult", 3);
    }

    private void hideResult() {
        resultBG.enabled = false;
        resultBG.GetComponentInChildren<Text>().text = "";
    }

    private void addReward(string name, int amount) {
        if (name.Contains("skin")) {
            PlayerPrefs.SetInt(name, 1);
        } else {
            int number = PlayerPrefs.GetInt(name) + amount;
            PlayerPrefs.SetInt(name, number);
        }
    }

    private bool startedToday() {
        return PlayerPrefs.HasKey(todayDate);
    }

    private bool addWatchedToday() {
        return PlayerPrefs.HasKey("add" + todayDate);
    }

    private void setStartButton() {
        startButton.GetComponentInChildren<Text>().text = "Start";
    }

    private void setWatchAdButton() {
        startButton.GetComponentInChildren<Text>().text = "Watch Ad";
    }

    private void setDailyLimitDoneButton() {
        startButton.GetComponentInChildren<Text>().text = "You used daily limit";
    }
}
