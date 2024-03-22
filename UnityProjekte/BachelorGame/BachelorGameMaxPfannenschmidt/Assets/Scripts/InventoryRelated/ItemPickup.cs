using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable {
    public Item Item;
    public GameObject HoverUi;
    public GameObject Player;
    
    
   public void Interact()
    {// wird ein Item Aufgehoben, wird es der Inventar Liste hinzugefügt. Das ItemGameObject in der Welt wird zerstört und das Inventar wird geöffnet.
        InventarManager.Instance.Add(Item);
        Destroy(gameObject);
        HUDControlls ic = Player.GetComponent<HUDControlls>();
        ic.openInventory();  
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

