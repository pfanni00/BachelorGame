using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSteuerung : MonoBehaviour
{ 

public GameObject SteuerungUI;
private bool SteuerungIsVisible;

void Start()
{
    SteuerungIsVisible = false;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
    public void SteuerungButton()
    {
        if(SteuerungIsVisible == true)
        {
            SteuerungUI.SetActive(false);
            SteuerungIsVisible = false;
        }
        else if (SteuerungIsVisible == false)
        {
            SteuerungUI.SetActive(true);
            SteuerungIsVisible = true;
        }
    }
}
