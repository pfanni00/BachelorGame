using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggle : MonoBehaviour
{
public Toggle toggle;

//[SerializeField]
public List<GameObject> SelectedItem = new List<GameObject>();

//[SerializeField]
public List<GameObject> OtherItem = new List<GameObject>();
public string[] itemTags = new string[] {"ItemTabletten","ItemPostkarte"};
  
  public void AssignToggle(string Selectedtag)
    {
        //Fetch the Toggle GameObject
        toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate {
        ToggleValueChanged(toggle);
        });

        //alle Item Prefabs die dem Toggle untergeordnet sind werden den Selected Items hinzugefügt
		    GameObject[] selectedobjects = GameObject.FindGameObjectsWithTag(Selectedtag);
        SelectedItem.AddRange(selectedobjects);

        //Schleife durchsucht alle bekannten Item Tags und weißt Alle Assets mit dem einem anderen als dem SelectiertenTag  zu OtherItems
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
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (toggle.isOn == true)
        {

        }
    }
}
