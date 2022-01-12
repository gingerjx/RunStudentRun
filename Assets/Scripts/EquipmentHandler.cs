using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentHandler : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("KebabQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("KebabBoost") ? PlayerPrefs.GetInt("KebabBoost").ToString() : "0";
        GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("InsuranceBoost") ? PlayerPrefs.GetInt("InsuranceBoost").ToString() : "0";
        GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("DeadlineBoost") ? PlayerPrefs.GetInt("DeadlineBoost").ToString() : "0";
    }

}
