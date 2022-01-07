using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInstruction : MonoBehaviour
{
    public void handleInstruction()
    {
        Canvas mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Canvas instructionCanvas = GameObject.Find("InstructionCanvas").GetComponent<Canvas>();
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
