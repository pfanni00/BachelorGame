using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public GameObject[] UITabletten;
    public GameObject[] UIPostkarte;
    // Start is called before the first frame update
    
    public void SelectTabletten()
    {
        Debug.Log("SelectTabletten");
        foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(true);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
        
    }

    public void SelectPostkarte()
    {
                Debug.Log("SelectPostkarte");

       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(true);
        }
    }

}
