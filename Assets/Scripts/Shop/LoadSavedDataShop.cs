using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSavedDataShop : MonoBehaviour
{
    void Start()
    {
        setIntLabel("KnowledgePoints", "KnowledgePoints"); 
        setIntLabel("Coins", "Coins");
        setIntLabel("InsuranceBoost", "InsuranceAmount"); 
        setIntLabel("DeadlineBoost", "DeadlineAmount"); 
        setIntLabel("KebabBoost", "KebabAmount");  
    }

    void setIntLabel(string prefName, string uiName) {  
        string value =   PlayerPrefs.HasKey(prefName) ? "" + PlayerPrefs.GetInt(prefName) : "0";
        GameObject.Find(uiName).GetComponent<Text>().text = value;
    }
}
