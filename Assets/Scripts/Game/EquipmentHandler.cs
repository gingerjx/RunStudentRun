using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentHandler : MonoBehaviour
{

    double KebabCooldown, InsuranceCooldown, DeadlineCooldown;
    bool isKebabOnCooldown = false, isInsuranceOnCooldown = false, isDeadlineOnCooldown = false;
    double KebabTimer = 0, InsuranceTimer = 0, DeadlineTimer = 0;
    void Awake()
    {
        GameObject.Find("KebabQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("KebabBoost") ? PlayerPrefs.GetInt("KebabBoost").ToString() : "0";
        GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("InsuranceBoost") ? PlayerPrefs.GetInt("InsuranceBoost").ToString() : "0";
        GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("DeadlineBoost") ? PlayerPrefs.GetInt("DeadlineBoost").ToString() : "0";
        KebabCooldown = InsuranceCooldown = DeadlineCooldown = 40f;
    }

    private void Update()
    {
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled == true && isKebabOnCooldown)
        {
            KebabTimer += Time.deltaTime;
            GameObject.Find("KebabButtonText").GetComponent<Text>().text = (KebabCooldown - KebabTimer).ToString("00.00");
        }
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled == true && isInsuranceOnCooldown)
        {
            InsuranceTimer += Time.deltaTime;
            GameObject.Find("InsuranceButtonText").GetComponent<Text>().text = (InsuranceCooldown - InsuranceTimer).ToString("00.00");
        }
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled == true && isDeadlineOnCooldown)
        {
            DeadlineTimer += Time.deltaTime;
            GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = (DeadlineCooldown - DeadlineTimer).ToString("00.00");
        }


        if(KebabTimer>=KebabCooldown)
        {
            isKebabOnCooldown = false;
            GameObject.Find("KebabButton").GetComponent<Button>().interactable = true;
            GameObject.Find("KebabButtonText").GetComponent<Text>().text = "Use";

        }

        if (InsuranceTimer >= InsuranceCooldown)
        {
            isInsuranceOnCooldown = false;
            GameObject.Find("InsuranceButton").GetComponent<Button>().interactable = true;
            GameObject.Find("InsuranceButtonText").GetComponent<Text>().text = "Use";

        }

        if (DeadlineTimer >= DeadlineCooldown)
        {
            isDeadlineOnCooldown = false;
            GameObject.Find("DeadlineButton").GetComponent<Button>().interactable = true;
            GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = "Use";


        }


    }

    public void KebabUse() //TODO: functionality
    {
        if (PlayerPrefs.HasKey("KebabBoost") && PlayerPrefs.GetInt("KebabBoost") > 0 && !isKebabOnCooldown)
        {
            PlayerPrefs.SetInt("KebabBoost", PlayerPrefs.GetInt("KebabBoost") - 1);
            GameObject.Find("KebabQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("KebabBoost") ? PlayerPrefs.GetInt("KebabBoost").ToString() : "0";
            isKebabOnCooldown = true;
            KebabTimer = 0;
            GameObject.Find("KebabButton").GetComponent<Button>().interactable = false;
            GameObject.Find("KebabButtonText").GetComponent<Text>().text = (KebabCooldown - KebabTimer).ToString("00.00");
        }

    }

    public void InsuranceUse() //TODO: functionality
    {
        if (PlayerPrefs.HasKey("InsuranceBoost") && PlayerPrefs.GetInt("InsuranceBoost") > 0 && !isInsuranceOnCooldown)
        {
            PlayerPrefs.SetInt("InsuranceBoost", PlayerPrefs.GetInt("InsuranceBoost") - 1);
            GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("InsuranceBoost") ? PlayerPrefs.GetInt("InsuranceBoost").ToString() : "0";
            isInsuranceOnCooldown = true;
            InsuranceTimer = 0;
            GameObject.Find("InsuranceButton").GetComponent<Button>().interactable = false;
            GameObject.Find("InsuranceButtonText").GetComponent<Text>().text = (InsuranceCooldown - InsuranceTimer).ToString("00.00");

        }
    }

    public void DeadlineUse() //TODO: functionality
    {
        if (PlayerPrefs.HasKey("DeadlineBoost") && PlayerPrefs.GetInt("DeadlineBoost") > 0 && !isDeadlineOnCooldown)
        {
            PlayerPrefs.SetInt("DeadlineBoost", PlayerPrefs.GetInt("DeadlineBoost") - 1);
            GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = PlayerPrefs.HasKey("DeadlineBoost") ? PlayerPrefs.GetInt("DeadlineBoost").ToString() : "0";
            isDeadlineOnCooldown = true;
            DeadlineTimer = 0;
            GameObject.Find("DeadlineButton").GetComponent<Button>().interactable = false;
            GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = (DeadlineCooldown - DeadlineTimer).ToString("00.00");

        }
    }

}
