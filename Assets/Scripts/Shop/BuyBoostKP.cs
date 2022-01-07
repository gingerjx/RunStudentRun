using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBoostKP : MonoBehaviour
{
    public int insuranceCost = 100;
    public int deadlineCost = 200;
    public int kebabCost = 30;

    public Text insuranceText;
    public Text deadlineText;
    public Text kebabText;
    public Text kpText;

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
        int kp = PlayerPrefs.HasKey("KnowledgePoints") ? PlayerPrefs.GetInt("KnowledgePoints") : 0;
        
        if (boostCost <= kp) {
            PlayerPrefs.SetInt("KnowledgePoints", kp - boostCost);
            
            int currentBoostAmount = PlayerPrefs.HasKey(boostName) ? PlayerPrefs.GetInt(boostName) : 0;
            currentBoostAmount++;
            PlayerPrefs.SetInt(boostName, currentBoostAmount);

            text.text = "" + currentBoostAmount;
            kpText.text = "" + (kp - boostCost);
        } else {
            /* Not enough KP to buy */
        }

    }
}
