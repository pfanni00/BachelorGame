using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// dieses Script fixt einen Bug welcher das Layout von TextMeshPro objecten zerstört. 
public class FixTMP : MonoBehaviour
{
    public TMP_Text Text;

    void Start()
    {
        RemoveR();
    }

    public void RemoveR()
    {
        Text.text = Text.text.Replace("\r", "");
    }

}
