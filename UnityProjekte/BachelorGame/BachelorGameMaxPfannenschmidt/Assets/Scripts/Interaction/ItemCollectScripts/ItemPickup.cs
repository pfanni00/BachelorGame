using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable {
    
    // dieses Script managed das aufheben von Items

    // Item scriptable Object enthält die daten des Items
    public Item Item;

    // HoverUi wird beim ansehen des Items eingeblendet
    public GameObject HoverUi;

    
   public void Interact()
    {// interaction mit InteractObjecten ist nur möglich wenn InteractionEnabled im GameManager auf true gesetzt ist. 
    if (GameManager.Instance.InteractionEnabled == true)
    {
        // Item wird im InventarManager dem inventar hinzugefügt
        InventarManager.Instance.Add(Item);
        
        // GameObject des World items wird gelöscht
        Destroy(gameObject);

        // Inventar wird geöffnet
        HUDControlls.Instance.openInventory();  
    }
    }

    public void HoverInteract()
    {
        // Hover Ui wird eingeblendet
        HoverUi.SetActive(true);
    }

public void HoverInteractOFF()
    {
        // Hover Ui wird ausgeblendet
        HoverUi.SetActive(false);
    }
}

