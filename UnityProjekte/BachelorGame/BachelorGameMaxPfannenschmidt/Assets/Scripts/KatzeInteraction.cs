using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeInteraction : MonoBehaviour, IInteractable {
    public GameObject HoverUi;
    public GameObject Player;
    
    
   public void Interact()
    {
        HUDControlls ic = Player.GetComponent<HUDControlls>();
        ic.openDialogsystem();  
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

