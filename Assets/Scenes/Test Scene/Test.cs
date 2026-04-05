using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void onFistDetected()
    {
        Debug.Log("Fist Detected.");
        text.text = "Fist Detected.";
    }

    public void onOKDetected()
    {
        Debug.Log("OK Detected.");
        text.text = "OK Detected.";
    }

    public void onNothingDetected()
    {
        Debug.Log("Nothing Detected.");
        text.text = "Nothing Detected.";
    }
}
