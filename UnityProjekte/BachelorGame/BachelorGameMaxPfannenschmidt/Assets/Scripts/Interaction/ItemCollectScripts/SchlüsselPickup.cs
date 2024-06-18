

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchlüsselPickup : MonoBehaviour, IInteractable {
    // dieses Script verwaltet das Interagieren mit dem Schlüssel Item. Anders als die anderen Items wird der Schlüssel nicht im Inventar angezeigt, sondern öffnet das verschlossene Tagebuch.
    // Item des geschlossenen Tagebuchs enthält daten der Items
    public Item tagebuchGeschlossen;

    // Item des geöffneten Tagebuchs enthält daten der Items
    public Item tagebuchGeöffnet;  
    
    // HoverUI 
    public GameObject HoverUi;
    
    
   public void Interact()
    {// interaction mit InteractObjecten ist nur möglich wenn InteractionEnabled im GameManager auf true gesetzt ist. 
        if (GameManager.Instance.InteractionEnabled == true)

        {// wird der Schlüssel für EmmasTagebuch aufgehoben. Wird Emmas Tagebuch Geschlossen mit Emmas Tagebuch Geöffnet ausgetauscht
            InventarManager.Instance.Remove(tagebuchGeschlossen);
            InventarManager.Instance.Add(tagebuchGeöffnet);

            // gameObject des Schlüssels wird gelöscht.
            Destroy(gameObject);

            // inventar wird geöffnet
            HUDControlls.Instance.openInventory();  
        }
   }
    public void HoverInteract()
    {
        // HoverUI wird eingeblendet
        HoverUi.SetActive(true);
    }

public void HoverInteractOFF()
    {
        // HoverUI wird ausgeblendet
        HoverUi.SetActive(false);
    }
}

