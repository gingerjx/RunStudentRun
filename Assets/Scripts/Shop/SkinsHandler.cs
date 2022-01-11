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
            initActiveButton(skin);
            initBuyButtons(skin);
        }
    }

    private void initBuyButtons(Skin skin) {
        if (skin.KP == null || skin.coins == null)
            return;

        skin.KP.GetComponentInChildren<Text>().text = "" + skin.KPCost;
        skin.coins.GetComponentInChildren<Text>().text = "" + skin.coinsCost;

        if (skin.state == ActivationState.UNAVAILABLE) {
            skin.KP.image.overrideSprite = inactiveImage;
            skin.coins.image.overrideSprite = inactiveImage;
        } else {
            skin.KP.image.overrideSprite = unavailableImage;
            skin.coins.image.overrideSprite = unavailableImage;
        }
    }

    private void initActiveButton(Skin skin) {
        bool isSkinActive = PlayerPrefs.HasKey(skin.name) && (PlayerPrefs.GetInt(skin.name) != 0);
        bool hasSkin = PlayerPrefs.HasKey("ActiveSkin") && (PlayerPrefs.GetString("ActiveSkin") == skin.name);

        if (isSkinActive)
            activatedInit(skin);
        else if (hasSkin)
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

    // private void buyButtonsActive() {
    //     KPButton.image.overrideSprite = inactiveImage;
    //     CoinsButton.image.overrideSprite = inactiveImage;
    // }

    // private void buyButtonInactive() {
    //     KPButton.image.overrideSprite = unavailableImage;
    //     CoinsButton.image.overrideSprite = unavailableImage;
    // }
}
