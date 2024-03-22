using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggle : MonoBehaviour
{
public Toggle toggle;

public string thisTag;

public GameObject inventarManager;



    void Awake()
    {
        inventarManager = GameObject.Find("InventarManager");
    	Debug.Log("Hier ist der Erste:");
        Debug.Log(inventarManager);
    }
// Diese Funktion wird jedem einzelnen Toggle Object angefügt. Wenn sich der Wert des Toggel verändert wird entsprechend der Variable thistag welche für jedes Toggle Object definiert wird, über das script ToggleManager die entsprechende UI Gruppe angezeigt.
    public void ToggleValueChanged(Toggle change)
    {
        if (toggle.isOn == true)
        {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectItem(thisTag);
           
    }}

}


    
