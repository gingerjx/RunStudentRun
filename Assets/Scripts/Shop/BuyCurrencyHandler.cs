using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCurrencyHandler : MonoBehaviour
{
    public Text KPText;
    public void buy100KP() {
        buyKP(100);
    }

    public void buy250KP() {
        buyKP(250);
    }

    public void buy600KP() {
        buyKP(600);
    }

    private void buyKP(int amount) {
        /* Payment implementation */
        var isPaid = true;
        if (isPaid) {
            int currentKP = PlayerPrefs.HasKey("KnowledgePoints") ? PlayerPrefs.GetInt("KnowledgePoints") : 0;
            PlayerPrefs.SetInt("KnowledgePoints", currentKP + amount);
            KPText.text = "" + PlayerPrefs.GetInt("KnowledgePoints");
        }
    }
}
