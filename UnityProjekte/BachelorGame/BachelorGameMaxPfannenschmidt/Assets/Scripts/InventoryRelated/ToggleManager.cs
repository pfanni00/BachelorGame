using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public GameObject[] UITabletten;
    public GameObject[] UIPostkarte;

    public GameObject[] UIBriefanMama;
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
        foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
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
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
    }

    public void SelectBriefanMama()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(true);
        }
    }

}
