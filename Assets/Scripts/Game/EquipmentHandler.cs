using UnityEngine;
using UnityEngine.UI;
using static System.Linq.Enumerable;

public class EquipmentHandler : MonoBehaviour
{
    const int KEBAB_ENERGY = 20;
    const int INSURANCE_TIME = 10;
    const int DEADLINE_TIME = 30;

    double KebabCooldown, InsuranceCooldown, DeadlineCooldown;
    static bool isKebabOnCooldown, isInsuranceOnCooldown, isDeadlineOnCooldown;
    static double KebabTimer, InsuranceTimer, DeadlineTimer;
    void Awake()
    {
        GameObject.Find("KebabQuantity").GetComponent<Text>().text = PlayerPrefs.GetInt("KebabBoost", 0).ToString();
        GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = PlayerPrefs.GetInt("InsuranceBoost", 0).ToString();
        GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = PlayerPrefs.GetInt("DeadlineBoost", 0).ToString();
        KebabCooldown = InsuranceCooldown = DeadlineCooldown = 40f;
        KebabTimer = InsuranceTimer = DeadlineTimer = 0f;
        isKebabOnCooldown = isInsuranceOnCooldown = isDeadlineOnCooldown = false;
        Debug.Log("ok");
    }

    private void Update()
    {
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled && isKebabOnCooldown)
        {
            KebabTimer += Time.deltaTime;
            GameObject.Find("KebabButtonText").GetComponent<Text>().text = (KebabCooldown - KebabTimer).ToString("00.00");
        }
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled && isInsuranceOnCooldown)
        {
            InsuranceTimer += Time.deltaTime;
            GameObject.Find("InsuranceButtonText").GetComponent<Text>().text = (InsuranceCooldown - InsuranceTimer).ToString("00.00");
        }
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled && isDeadlineOnCooldown)
        {
            DeadlineTimer += Time.deltaTime;
            GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = (DeadlineCooldown - DeadlineTimer).ToString("00.00");
        }
        
        if (KebabTimer >= KebabCooldown)
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

    public void KebabUse()
    {
        if (PlayerPrefs.GetInt("KebabBoost", 0) <= 0 || isKebabOnCooldown) return;
        PlayerPrefs.SetInt("KebabBoost", PlayerPrefs.GetInt("KebabBoost") - 1);
        GameObject.Find("KebabQuantity").GetComponent<Text>().text = PlayerPrefs.GetInt("KebabBoost", 0).ToString();
        isKebabOnCooldown = true;
        KebabTimer = 0;
        GameObject.Find("KebabButton").GetComponent<Button>().interactable = false;
        GameObject.Find("KebabButtonText").GetComponent<Text>().text = (KebabCooldown - KebabTimer).ToString("00.00");
        GameController.addEnergy(KEBAB_ENERGY);
    }

    public void InsuranceUse()
    {
        if (PlayerPrefs.GetInt("InsuranceBoost", 0) <= 0 || isInsuranceOnCooldown) return;
        PlayerPrefs.SetInt("InsuranceBoost", PlayerPrefs.GetInt("InsuranceBoost") - 1);
        GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = PlayerPrefs.GetInt("InsuranceBoost", 0).ToString();
        isInsuranceOnCooldown = true;
        InsuranceTimer = 0;
        GameObject.Find("InsuranceButton").GetComponent<Button>().interactable = false;
        GameObject.Find("InsuranceButtonText").GetComponent<Text>().text = (InsuranceCooldown - InsuranceTimer).ToString("00.00");
    }

    public void DeadlineUse()
    {
        if (PlayerPrefs.GetInt("DeadlineBoost", 0) <= 0 || isDeadlineOnCooldown) return;
        PlayerPrefs.SetInt("DeadlineBoost", PlayerPrefs.GetInt("DeadlineBoost") - 1);
        GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = PlayerPrefs.GetInt("DeadlineBoost", 0).ToString();
        isDeadlineOnCooldown = true;
        DeadlineTimer = 0;
        GameObject.Find("DeadlineButton").GetComponent<Button>().interactable = false;
        GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = (DeadlineCooldown - DeadlineTimer).ToString("00.00");
    }

    public static bool IsInsuranceBoostActive() => Range(0, INSURANCE_TIME).Contains(Mathf.FloorToInt((float) InsuranceTimer)) && isInsuranceOnCooldown;
    public static bool IsDeadlineBoostActive() => Range(0, DEADLINE_TIME).Contains(Mathf.FloorToInt((float) DeadlineTimer)) && isDeadlineOnCooldown;
}
