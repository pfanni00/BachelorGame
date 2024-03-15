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

            if (thisTag == "ItemTabletten")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectTabletten();
            }else if(thisTag =="ItemPostkarte")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectPostkarte(); 
            }else if(thisTag =="BriefanMama")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectBriefanMama();  
            }else if(thisTag =="EmmasTagebuchGeöffnet")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectEmmasTagebuchGeöffnet();  
            }else if(thisTag =="EmmasTagebuchGeschlossen")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectEmmasTagebuchGeschlossen();  
            }
            else if(thisTag =="EmmasTagebuchGeöffnet")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectEmmasTagebuchGeöffnet();  
            }
            else if (thisTag=="ZerissenerZettel")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectZerissenerZettel();       
            }
            else if (thisTag=="Patientenaktie")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectPatientenaktie();       
            }
        }else if (toggle.isOn != true)
        {
            
        }
    }
}

    
