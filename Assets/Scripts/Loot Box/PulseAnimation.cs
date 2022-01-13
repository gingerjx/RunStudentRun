using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseAnimation : MonoBehaviour
{
    private Image lootbox;
    private RewardDraw drawScript;
    private Image resultBG;

    public float minimum = 0.3f;
    public float maximum = 1f;
    public float cyclesPerSecond = 2.0f;
    public float acceleration = 1.01f;

    private float a;
    private bool increasing = true;
    private bool blink = false;
    Color color;    

    void Start() {
        lootbox = GameObject.Find("Lootbox").GetComponent<Image>();
        drawScript = GameObject.Find("RewardDrawHandler").GetComponent<RewardDraw>();

        resultBG = GameObject.Find("ResultBG").GetComponent<Image>();
        hideResult();

        color = lootbox.color;
        a = maximum;
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

        hideResult();
        blink = true;
        Invoke("draw", 2);
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
}
