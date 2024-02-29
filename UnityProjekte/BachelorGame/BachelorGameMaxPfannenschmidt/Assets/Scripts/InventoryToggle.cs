using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggle : MonoBehaviour
{
public Toggle toggle;

[SerializeField]
//a list with all Prefabs including ItemDescriptions and ItemModel for the currently Selected ItemName Toggle
private List<GameObject> SelectedItem = new List<GameObject>();

[SerializeField]
//a list with all Prefabs including ItemDescriptions and ItemModel for the currently Unselected ItemName Toggles
private List<GameObject> OtherItem = new List<GameObject>();

//a list with all Possible Tags for all Items. Each Item has its own already defined Tag
public string[] itemTags = new string[] {"ItemTabletten","ItemPostkarte"};

//This Method SHOULD look for all of the Prefabs with the Selectedtag and assignes the Game Objects to SelectedItem. It also assignes all Game Object with aTag != ItemTag to OtherObjects  
public void AssignToggle(string Selectedtag)
    {


		    GameObject[] selectedobjects = GameObject.FindGameObjectsWithTag(Selectedtag);
        SelectedItem.AddRange(selectedobjects);

        foreach (string s in itemTags)
        {
          if (s != Selectedtag)
        {
        GameObject[] otherobjects = GameObject.FindGameObjectsWithTag(s);
        OtherItem.AddRange(otherobjects);
        }
        }

    }

    public void TestMethod(string Selectedtag)
    {
      Debug.Log(Selectedtag);
/*
            //Fetch the Toggle GameObject
        toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate {
        ToggleValueChanged(toggle);
        });
*/
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (toggle.isOn == true)
        {

        }
    }
}
