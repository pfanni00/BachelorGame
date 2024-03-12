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

    //Output the new state of the Toggle into Text
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
            }
        }else if (toggle.isOn != true)
        {
            
        }
    }
}

    
