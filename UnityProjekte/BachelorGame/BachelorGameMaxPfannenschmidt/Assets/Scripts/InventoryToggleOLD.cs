using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggleOLD : MonoBehaviour
{
public Toggle toggle;

public string thisTag;

//a list with all Prefabs including ItemDescriptions and ItemModel for the currently Selected ItemName Toggle
private GameObject[] SelectedItem;


//a list with all Prefabs including ItemDescriptions and ItemModel for the currently Unselected ItemName Toggles
private GameObject[] OtherItem;

//a list with all Possible Tags for all Items. Each Item has its own already defined Tag
public string[] itemTags = new string[] {"ItemTabletten","ItemPostkarte"};

//This Method SHOULD look for all of the Prefabs with the Selectedtag and assignes the Game Objects to SelectedItem. It also assignes all Game Object with aTag != ItemTag to OtherObjects  

void Update()
{
    SelectedItem = GameObject.FindGameObjectsWithTag(thisTag);
    //Debug.Log(SelectedItem);

    foreach (string s in itemTags)
        {
            if (s != thisTag)
            {
                OtherItem = GameObject.FindGameObjectsWithTag(s);
            }
        }
}
public void AssignToggle(string Selectedtag)
    {
        //Fetch the Toggle GameObject
        toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate {
        ToggleValueChanged(toggle);
        });

		

    }

    public void TestMethod(string Selectedtag)
    {
      Debug.Log(Selectedtag);

             /*   GameObject[] selectedobjects = GameObject.FindGameObjectsWithTag(Selectedtag);
        SelectedItem.AddRange(selectedobjects);

        foreach (string s in itemTags)
        {
          if (s != Selectedtag)
        {
        GameObject[] otherobjects = GameObject.FindGameObjectsWithTag(s);
        OtherItem.AddRange(otherobjects);
        }
        }*/

    }

    //Output the new state of the Toggle into Text
    public void ToggleValueChanged(Toggle change)
    {
        Debug.Log("ToggleHasChanged");
        if (toggle.isOn == true)
        {
            //SelectedItem = GameObject.FindGameObjectsWithTag(thisTag);

            foreach (GameObject selectedItems in SelectedItem)
            {
            selectedItems.SetActive(true);
            }
        
           
            foreach (GameObject otherItems in SelectedItem)
            {
            otherItems.SetActive(false);
            }
                
            }
        }
    }

    
