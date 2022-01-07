using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInstruction : MonoBehaviour
{
    public void handleInstruction()
    {
        Canvas instructionCanvas = GameObject.Find("InstructionCanvas").GetComponent<Canvas>();
        GameObject mainCanvasObject = GameObject.Find("Canvas");
        if (mainCanvasObject == null) // jeżeli jesteśmy w menu pauzy 
        {
            mainCanvasObject = GameObject.Find("PauseCanvas");
        }
        Canvas mainCanvas = mainCanvasObject.GetComponent<Canvas>();
        if (mainCanvas.enabled)
        {
            mainCanvas.enabled = false;
            instructionCanvas.enabled = true;
        }
        else
        {
            mainCanvas.enabled = true;
            instructionCanvas.enabled = false;
        }
    }
}
