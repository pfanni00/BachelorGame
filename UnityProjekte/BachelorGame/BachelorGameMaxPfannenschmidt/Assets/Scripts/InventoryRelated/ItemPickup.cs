using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable {
    public Item Item;
    public GameObject HoverUi;
    
    
   public void Interact()
    {
        InventarManager.Instance.Add(Item);
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

