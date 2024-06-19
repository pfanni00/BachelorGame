using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSteuerung : MonoBehaviour
{ // Steuerungs controller des Hauptmenüs 

// UI elemente der Steuerungsanzeige
public GameObject SteuerungUI;

// variable die bestimmt ob Steuerung sichtbar ist.
private bool SteuerungIsVisible;

void Start()
{
    // zum start ist die Steuerung nicht sichtbar
    SteuerungIsVisible = false;

    // Cursor ist sichtbar und kann bewegt werden 
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
    // Funktion wird beim Clicken auf den Steuerung Button ausgelöst
    public void SteuerungButton()
    {
        // steuerung sichtbarkeit wird invertiert. 
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
