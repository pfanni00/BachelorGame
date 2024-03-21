

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchlüsselPickup : MonoBehaviour, IInteractable {
    public Item tagebuchGeschlossen;
    public Item tagebuchGeöffnet;    
    public GameObject HoverUi;
    public GameObject Player;
    
    
   public void Interact()
    {// wird der Schlüssel für EmmasTagebuch aufgehoben. Wird Emmas Tagebuch Geschlossen mit Emmas Tagebuch Geöffnet ausgetauscht
        InventarManager.Instance.Remove(tagebuchGeschlossen);
        InventarManager.Instance.Add(tagebuchGeöffnet);
        Destroy(gameObject);
        InventoryControlls ic = Player.GetComponent<InventoryControlls>();
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

