

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientenaktiePickup : MonoBehaviour, IInteractable {
    public GameObject PatientenaktieLogicGO;

    public GameObject HoverUi;
    //public GameObject Player;
    

    
    
   public void Interact()
    {// wird ein ZerissenerZettel Aufgehoben, verwaltet das Script PatientenaktieLogic welches Item angezeigt wird. Bei einem Zerissenen Zettel wird dieser Als item angezeigt bei Zwei wird dei Patientenaktie Angezeigt.
       PatientenaktieLogic pl = PatientenaktieLogicGO.GetComponent<PatientenaktieLogic>();
     pl.PatientenaktieStates();
     Destroy(gameObject);
    }

    public void HoverInteract()
    {
        HoverUi.SetActive(true);
    }

public void HoverInteractOFF()
    {
        HoverUi.SetActive(false);
    }
}

