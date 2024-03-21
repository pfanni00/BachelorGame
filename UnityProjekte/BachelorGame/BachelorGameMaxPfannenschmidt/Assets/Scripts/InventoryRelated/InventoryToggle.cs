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
/*
    public void SelectItem(string tag)
{
           if (tag == "ItemTabletten")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectTabletten();
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();
            }else if(tag =="ItemPostkarte")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectPostkarte(); 
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();
            }else if(tag =="BriefanMama")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectBriefanMama();  
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();
            }else if(tag =="EmmasTagebuchGeöffnet")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectEmmasTagebuchGeöffnet();
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();  
            }else if(tag =="EmmasTagebuchGeschlossen")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectEmmasTagebuchGeschlossen();  
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();
            }
            else if(tag =="EmmasTagebuchGeöffnet")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectEmmasTagebuchGeöffnet(); 
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select(); 
            }
            else if (tag=="ZerissenerZettel")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectZerissenerZettel();   
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();    
            }
            else if (tag=="MeinePatientenaktie")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectPatientenaktie();
            ItemController ic = gameObject.GetComponent<ItemController>();
            ic.Select();       
            }
}*/
}


    
