using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryToggle : MonoBehaviour
{
public Toggle toggle;

[SerializeField]
private GameObject[] SelectedItem;

[SerializeField]
private GameObject[] OtherItems;
public string[] itemTags = new string[] {"ItemTabletten","ItemPostkarte"};
  
  public void AssignToggle()
    {
        //Fetch the Toggle GameObject
        toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate {
        ToggleValueChanged(toggle);

        //Tag dieses GameObjectes wird zugewiesen
        string thisTag = gameObject.tag;

        //Schleife durchsucht alle bekannten Item Tags und weißt Alle Assets mit dem Aktuellen ItemTag zu SelectedItem und alle übrigen Assets zu OtherItems
        foreach (string s in itemTags)
        {
          if (gameObject.CompareTag(thisTag))
        {
          SelectedItem = GameObject.FindGameObjectsWithTag(thisTag);
        } else if (!gameObject.CompareTag(thisTag))
        {
          OtherItems = GameObject.FindGameObjectsWithTag(s);
        }
        }

            Debug.Log(SelectedItem);
            Debug.Log(OtherItems);

        });
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (toggle.isOn == true)
        {

        }
    }
}
