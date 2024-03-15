using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientenaktiePickup : MonoBehaviour
{
  //dieses Script dient als ersatz des Pickup Scriptes für das Item Patientenaktie und die dazugehörigen Zerrissener Zettel Items. 
public GameObject PatientenaktieLogicGO;

    
    void Pickup()
    {
     PatientenaktieLogic pl = PatientenaktieLogicGO.GetComponent<PatientenaktieLogic>();
            pl.PatientenaktieStates();
                  Destroy(gameObject);

    }

    private void OnMouseDown()
    {
        Pickup();
    }
}