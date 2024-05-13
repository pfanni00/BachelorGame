using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
