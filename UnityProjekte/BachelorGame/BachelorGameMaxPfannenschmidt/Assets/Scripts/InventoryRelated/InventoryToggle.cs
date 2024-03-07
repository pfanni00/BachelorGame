using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggle : MonoBehaviour
{
public Toggle toggle;

public string thisTag;

public GameObject inventarManager;



    void Start()
    {
         inventarManager = GameObject.Find("InventarManager");

    }

    //Output the new state of the Toggle into Text
    public void ToggleValueChanged(Toggle change)
    {
        Debug.Log("ToggleHasChanged");
        if (toggle.isOn == true)
        {
                    Debug.Log("ToggleIsOn");

            if (thisTag == "ItemTabletten")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectTabletten();
            }else if(thisTag =="ItemPostkarte")
            {
            ToggleManager tm = inventarManager.GetComponent<ToggleManager>();
            tm.SelectPostkarte(); 
            }
        }else if (toggle.isOn != true)
        {
            
        }
    }
}

    
