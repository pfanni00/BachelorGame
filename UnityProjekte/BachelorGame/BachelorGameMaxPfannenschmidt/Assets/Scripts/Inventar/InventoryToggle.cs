using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggle : MonoBehaviour
{ // dieses Script wird jedem einzelnen InventarListe Prefab hinzugefügt und managed die Toggle Button funktion des Objectes

    // Toggle Object des GameObjectes
    public Toggle toggle;

// thisTag == Item name wird über ToggleManager weiterverwendet
public string thisTag;




   
//  Wenn sich der Wert des Toggel verändert wird entsprechend der Variable "thisTag" welche für jedes Toggle Object definiert wird, über das script ToggleManager die entsprechende UI Gruppe angezeigt.
    public void ToggleValueChanged(Toggle change)
    {
        if (toggle.isOn == true)
        {
            ToggleManager tm = InventarManager.Instance.GetComponent<ToggleManager>();
            tm.SelectItem(thisTag);
        }
    }

}


    
