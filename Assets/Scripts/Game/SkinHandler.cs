using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinHandler : MonoBehaviour
{
    public RuntimeAnimatorController skinNormalController;
    public RuntimeAnimatorController skin1Controller;
    public RuntimeAnimatorController skin2Controller;
    public RuntimeAnimatorController skin3Controller;
    public RuntimeAnimatorController skin4Controller;
    public RuntimeAnimatorController skin5Controller;
    public Animator playerAnimator;

    private Dictionary<string, RuntimeAnimatorController> controllers;

    void Start()
    {
       controllers = new Dictionary<string, RuntimeAnimatorController>(); 
       controllers.Add("skinNormal", skinNormalController);
       controllers.Add("skin1", skin1Controller);
       controllers.Add("skin2", skin2Controller);
       controllers.Add("skin3", skin3Controller);
       controllers.Add("skin4", skin4Controller);
       controllers.Add("skin5", skin5Controller);

       string activeSkin = PlayerPrefs.GetString("ActiveSkin");
       RuntimeAnimatorController activeController = controllers[activeSkin];
       playerAnimator.runtimeAnimatorController = activeController;
    }
}
