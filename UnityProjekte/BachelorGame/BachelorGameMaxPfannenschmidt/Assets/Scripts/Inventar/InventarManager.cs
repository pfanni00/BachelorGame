using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class InventarManager : MonoBehaviour
{
    public static InventarManager Instance;

    // Liste mit allen bereits eingesammelten Items.
    public List<Item> Items = new List<Item>();

    // UI Parent under dem die InventarListe Prefabs gespawned werden
    public Transform NameParent;

    // Game Object dem die InventarListe Prefabs assigned werden
    private GameObject ItemName;

    // Toggle Group der Item Liste 
    public ToggleGroup toggleGroup; 

    // Toggle des Jeweiligen InventarListen Prefabs
    private Toggle newToggle; 



    private void Awake()
    {
        Instance = this;
    }
    
    
    // Funktion wird 
    public void Add(Item item)
    {
        Items.Add(item);
        
        ListItems();
        
       // toggleGroupController sn = NameParent.GetComponent<toggleGroupController>();
       // sn.AddToggle();
        
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
                ListItems();
    }

    public void ListItems()
    {
// zu beginn der Methode werden alle InventarListe Prefabs aus der Item Liste Gelöscht
    foreach (Transform child in NameParent)
    {
        Destroy(child.gameObject);
    }

        //Jetzt wird jedes Toggle InventarListe Prefabs unter NameParent instanziert 
        foreach (var item in Items)
        {   // die InventarListen Prefabs werden dabei über die item.title variable der Items gefunden. 
            ItemName = item.title;
            GameObject IN = Instantiate(ItemName, NameParent) as GameObject;


         //fügt InventarListe Prefabs der ToggleGroup hinzu
          newToggle = IN.GetComponent<Toggle>(); 
          newToggle.group = toggleGroup;
          newToggle.isOn = true;
        
        // wenn das Item zum ersten mal im Inventar Instanziert wird wird es geöffnet. So wird ein neu eingesammeltes Item automatisch ausgewählt
        if (item.isNew == true)
            {
            SelectNewItem(item);
            //item.isNew = false;
            }
        }
    }
    
    void SelectNewItem(Item item)
    {
        // Neues Item wird über ToggleManager Script Selectiert
         ToggleManager it = gameObject.GetComponent<ToggleManager>();
            it.SelectItem(item.Itemtag);  
        // isNew variable wird auf false gesetzt 
            item.isNew = false;
    }
}
    


