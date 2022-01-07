using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBoostCoins : MonoBehaviour
{
    public int insuranceCost = 500;
    public int deadlineCost = 800;
    public int kebabCost = 200;

    public Text insuranceText;
    public Text deadlineText;
    public Text kebabText;
    public Text coinsText;

    public void buyInsurance() {
        buyBoost("InsuranceBoost", insuranceCost, insuranceText);
    }

    public void buyDeadline() {
        buyBoost("DeadlineBoost", deadlineCost, deadlineText);
    }

    public void buyKebab() {
        buyBoost("KebabBoost", kebabCost, kebabText);
    }

    private void buyBoost(string boostName, int boostCost, Text text) {
        int coins = PlayerPrefs.HasKey("Coins") ? PlayerPrefs.GetInt("Coins") : 0;
        
        if (boostCost <= coins) {
            Debug.Log(coins);
            Debug.Log(boostCost);
            
            PlayerPrefs.SetInt("Coins", coins - boostCost);
            
            int currentBoostAmount = PlayerPrefs.HasKey(boostName) ? PlayerPrefs.GetInt(boostName) : 0;
            currentBoostAmount++;
            PlayerPrefs.SetInt(boostName, currentBoostAmount);

            text.text = "" + currentBoostAmount;
            coinsText.text = "" + (coins - boostCost);
        } else {
            /* Not enough KP to buy */
        }

    }
}
