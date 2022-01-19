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
    
    private GameObject insuranceTimeLeft;
    private GameObject deadlineTimeLeft;
    private Vector3 insuranceTimeLeftPosition;
    private Vector3 deadlineTimeLeftPosition;

    int kebabQuan, insuranceQuan, deadlineQuan;

    void Awake()
    {
        insuranceTimeLeft = GameObject.Find("InsuranceTimeLeftImage");
        deadlineTimeLeft = GameObject.Find("DeadlineTimeLeftImage");
        insuranceTimeLeftPosition = insuranceTimeLeft.transform.position;
        deadlineTimeLeftPosition = deadlineTimeLeft.transform.position;
        KebabCooldown = InsuranceCooldown = DeadlineCooldown = 40f;
        KebabTimer = InsuranceTimer = DeadlineTimer = 0f;
        isKebabOnCooldown = isInsuranceOnCooldown = isDeadlineOnCooldown = false;

        kebabQuan = Mathf.Clamp(PlayerPrefs.GetInt("KebabBoost", 0), 0, 5);
        insuranceQuan = Mathf.Clamp(PlayerPrefs.GetInt("InsuranceBoost", 0), 0, 5);
        deadlineQuan = Mathf.Clamp(PlayerPrefs.GetInt("DeadlineBoost", 0), 0, 5);

        GameObject.Find("KebabQuantity").GetComponent<Text>().text = kebabQuan.ToString();
        GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = insuranceQuan.ToString();
        GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = deadlineQuan.ToString();
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
            updateInsuranceTimeLeft();
        }
        if (GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled && isDeadlineOnCooldown)
        {
            DeadlineTimer += Time.deltaTime;
            GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = (DeadlineCooldown - DeadlineTimer).ToString("00.00");
            updateDeadlineTimeLeft();
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
        updateInsuranceTimeLeft();
        updateDeadlineTimeLeft();
    }

    private void updateInsuranceTimeLeft()
    {
        var active = IsInsuranceBoostActive();
        var timeLeft = INSURANCE_TIME - Mathf.FloorToInt((float) InsuranceTimer);
        var timeLeftText = insuranceTimeLeft.GetComponentInChildren<Text>();
        timeLeftText.text = (active ? timeLeft : INSURANCE_TIME).ToString();
        timeLeftText.color = active && Range(0, 4).Contains(timeLeft) ? Color.red : Color.white;
        if (timeLeftText.color == Color.red)
        {
            var position = insuranceTimeLeftPosition + Random.insideUnitSphere * 2.5f;
            insuranceTimeLeft.transform.position = position;
        }
        else insuranceTimeLeft.transform.position = insuranceTimeLeftPosition;
        insuranceTimeLeft.SetActive(active);
    }
    
    private void updateDeadlineTimeLeft()
    {
        var active = IsDeadlineBoostActive();
        var timeLeft = DEADLINE_TIME - Mathf.FloorToInt((float) DeadlineTimer);
        var timeLeftText = deadlineTimeLeft.GetComponentInChildren<Text>();
        timeLeftText.text = (active ? timeLeft : DEADLINE_TIME).ToString();
        timeLeftText.color = active && Range(0, 4).Contains(timeLeft) ? Color.red : Color.white;
        if (timeLeftText.color == Color.red)
        {
            var position = deadlineTimeLeftPosition + Random.insideUnitSphere * 2.5f;
            deadlineTimeLeft.transform.position = position;
        }
        else deadlineTimeLeft.transform.position = deadlineTimeLeftPosition;
        deadlineTimeLeft.SetActive(active);
    }

    public void KebabUse()
    {
        if (kebabQuan <= 0 || isKebabOnCooldown) return;
        PlayerPrefs.SetInt("KebabBoost", PlayerPrefs.GetInt("KebabBoost") - 1);
        kebabQuan -= 1;
        GameObject.Find("KebabQuantity").GetComponent<Text>().text = kebabQuan.ToString();
        isKebabOnCooldown = true;
        KebabTimer = 0;
        GameObject.Find("KebabButton").GetComponent<Button>().interactable = false;
        GameObject.Find("KebabButtonText").GetComponent<Text>().text = (KebabCooldown - KebabTimer).ToString("00.00");
        GameController.addEnergy(KEBAB_ENERGY);
    }

    public void InsuranceUse()
    {
        if (insuranceQuan <=0 || isInsuranceOnCooldown) return;
        PlayerPrefs.SetInt("InsuranceBoost", PlayerPrefs.GetInt("InsuranceBoost") - 1);
        insuranceQuan -= 1;
        GameObject.Find("InsuranceQuantity").GetComponent<Text>().text = insuranceQuan.ToString();
        isInsuranceOnCooldown = true;
        InsuranceTimer = 0;
        GameObject.Find("InsuranceButton").GetComponent<Button>().interactable = false;
        GameObject.Find("InsuranceButtonText").GetComponent<Text>().text = (InsuranceCooldown - InsuranceTimer).ToString("00.00");
        updateInsuranceTimeLeft();
    }

    public void DeadlineUse()
    {
        if (deadlineQuan <= 0 || isDeadlineOnCooldown) return;
        PlayerPrefs.SetInt("DeadlineBoost", PlayerPrefs.GetInt("DeadlineBoost") - 1);
        deadlineQuan -= 1;
        GameObject.Find("DeadlineQuantity").GetComponent<Text>().text = deadlineQuan.ToString();
        isDeadlineOnCooldown = true;
        DeadlineTimer = 0;
        GameObject.Find("DeadlineButton").GetComponent<Button>().interactable = false;
        GameObject.Find("DeadlineButtonText").GetComponent<Text>().text = (DeadlineCooldown - DeadlineTimer).ToString("00.00");
        updateDeadlineTimeLeft();
    }

    public static bool IsInsuranceBoostActive() => Range(0, INSURANCE_TIME).Contains(Mathf.FloorToInt((float) InsuranceTimer)) && isInsuranceOnCooldown;
    public static bool IsDeadlineBoostActive() => Range(0, DEADLINE_TIME).Contains(Mathf.FloorToInt((float) DeadlineTimer)) && isDeadlineOnCooldown;
}
