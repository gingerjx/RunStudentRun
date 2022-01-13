using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsHandler : MonoBehaviour
{
    enum ActivationState
    {
        ACTIVATED,
        INACTIVATED,
        UNAVAILABLE
    }

    public Text kpLabel;
    public Text coinsLabel;

    public Sprite activeImage;
    public Sprite inactiveImage;
    public Sprite unavailableImage;

    public string skinNormalPrefName;
    public string skin1PrefName;
    public string skin2PrefName;
    public string skin3PrefName;
    public string skin4PrefName;
    public string skin5PrefName;

    public Button buttonNormal;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    public Button KPButton1;
    public Button KPButton2;
    public Button KPButton3;
    public Button KPButton4;
    public Button KPButton5;

    public Button CoinsButton1;
    public Button CoinsButton2;
    public Button CoinsButton3;
    public Button CoinsButton4;
    public Button CoinsButton5;

    public int KPCost1;
    public int KPCost2;
    public int KPCost3;
    public int KPCost4;
    public int KPCost5;

    public int coinsCost1;
    public int coinsCost2;
    public int coinsCost3;
    public int coinsCost4;
    public int coinsCost5;

    class Skin {
        public string name;
        public Button activation;
        public Button KP;
        public Button coins;
        public ActivationState state;
        public int KPCost;
        public int coinsCost;

        public Skin(string name, Button activation, Button KP, Button coins, int KPCost, int coinsCost) {
            this.name = name;
            this.activation = activation;
            this.KP = KP;
            this.coins = coins;
            this.KPCost = KPCost;
            this.coinsCost = coinsCost;
        }
    }

    List<Skin> skins;
    
    void Start()
    {  
        skins = new List<Skin>() {
            new Skin(skinNormalPrefName, buttonNormal, null, null, 0, 0),
            new Skin(skin1PrefName, button1, KPButton1, CoinsButton1, KPCost1, coinsCost1),
            new Skin(skin2PrefName, button2, KPButton2, CoinsButton2, KPCost2, coinsCost2),
            new Skin(skin3PrefName, button3, KPButton3, CoinsButton3, KPCost3, coinsCost3),
            new Skin(skin4PrefName, button4, KPButton4, CoinsButton4, KPCost4, coinsCost4),
            new Skin(skin5PrefName, button5, KPButton5, CoinsButton5, KPCost5, coinsCost5)
        };

        foreach (Skin skin in skins) {
            // PlayerPrefs.SetInt(skin.name, 0);

            initActiveButton(skin);
            initBuyButtons(skin);

            skin.activation.onClick.AddListener(() => {
                activateSkin(skin);
            });

            if (skin.KP == null || skin.coins == null)
                continue;

            skin.KP.onClick.AddListener(() => {
                buySkinForKP(skin);
            });
            skin.coins.onClick.AddListener(() => {
                buySkinForCoins(skin);
            });
        }

        // PlayerPrefs.SetInt("skinNormal", 1);
        // PlayerPrefs.SetString("ActiveSkin", "skinNormal");
    }

    private void initActiveButton(Skin skin) {
        bool skinAvailable = hasSkin(skin.name);
        bool isSkinActive = PlayerPrefs.HasKey("ActiveSkin") && (PlayerPrefs.GetString("ActiveSkin") == skin.name);

        if (isSkinActive)
            activatedInit(skin);
        else if (skinAvailable)
            inactivatedInit(skin);
        else
            unavailableInit(skin);
    }

    private void activatedInit(Skin skin) {
        skin.activation.image.overrideSprite = activeImage;
        skin.activation.GetComponentInChildren<Text>().text = "Activated";
        skin.state = ActivationState.ACTIVATED;
    }

    private void inactivatedInit(Skin skin) {
        skin.activation.image.overrideSprite = inactiveImage;
        skin.activation.GetComponentInChildren<Text>().text = "Use";
        skin.state = ActivationState.INACTIVATED;
    }

    private void unavailableInit(Skin skin) {
        skin.activation.image.overrideSprite = unavailableImage;
        skin.activation.GetComponentInChildren<Text>().text = "Unavailable";
        skin.state = ActivationState.UNAVAILABLE;
    }
 
    private void initBuyButtons(Skin skin) {
        if (skin.KP == null || skin.coins == null)
            return;

        skin.KP.GetComponentInChildren<Text>().text = skin.KPCost + " KP";
        skin.coins.GetComponentInChildren<Text>().text = skin.coinsCost + " Coins";

        if (skin.state == ActivationState.UNAVAILABLE) {
            skin.KP.image.overrideSprite = inactiveImage;
            skin.coins.image.overrideSprite = inactiveImage;
        } else {
            skin.KP.image.overrideSprite = unavailableImage;
            skin.coins.image.overrideSprite = unavailableImage;
        }
    }

    private void buySkinForKP(Skin skin) {
        int kp = PlayerPrefs.HasKey("KnowledgePoints") ? PlayerPrefs.GetInt("KnowledgePoints") : 0;
        bool skinAvailable = hasSkin(skin.name);

        if (!skinAvailable && skin.KPCost <= kp) {
            PlayerPrefs.SetInt("KnowledgePoints", kp - skin.KPCost);
            PlayerPrefs.SetInt(skin.name, 1);
            skin.state = ActivationState.INACTIVATED;
            inactivatedInit(skin);
            initBuyButtons(skin);
            kpLabel.text = "" + (kp - skin.KPCost);
        } else {
            /* Not enough KP to buy */
        }
    }

    private void buySkinForCoins(Skin skin) {
        int coins = PlayerPrefs.HasKey("Coins") ? PlayerPrefs.GetInt("Coins") : 0;
        bool skinAvailable = hasSkin(skin.name);

        if (!skinAvailable && skin.coinsCost <= coins) {
            PlayerPrefs.SetInt("Coins", coins - skin.KPCost);
            PlayerPrefs.SetInt(skin.name, 1);
            skin.state = ActivationState.INACTIVATED;
            inactivatedInit(skin);
            initBuyButtons(skin);
            coinsLabel.text = "" + (coins - skin.coinsCost);
        } else {
            /* Not enough KP to buy */
        }
    }

    private void activateSkin(Skin skin) {
        if (skin.state == ActivationState.UNAVAILABLE)
            return;
            
        foreach (Skin s in skins) {
            if (s.state == ActivationState.ACTIVATED) {
                s.state = ActivationState.INACTIVATED; 
                inactivatedInit(s);
            }
        }

        skin.state = ActivationState.ACTIVATED;
        PlayerPrefs.SetString("ActiveSkin", skin.name); 
        activatedInit(skin);
    }

    private bool hasSkin(string name) {
        return PlayerPrefs.HasKey(name) && (PlayerPrefs.GetInt(name) != 0);
    }
}
