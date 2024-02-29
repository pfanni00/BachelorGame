using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class InventarManager : MonoBehaviour
{
    public static InventarManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform NameParent;
    public Transform DescriptionParent;
  //  public Transform ModelParent;
//    public Transform TextParent;

    public GameObject ItemName;
    public GameObject ItemDescription;
    public GameObject ItemText;
    public GameObject ItemModel;

    private GameObject ID;

    public ToggleGroup toggleGroup; 
   
    private Toggle newToggle; 

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
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
    }

    public void ListItems()
    {
        
        foreach (var item in Items)
        {
            if (item.isInstatiated == false)
            {
            ItemName = item.title;
            ItemDescription = item.description;
            
          //  ItemText = item.text;
           // ItemModel = item.model;

            GameObject IN = Instantiate(ItemName, NameParent) as GameObject;

            GameObject ID = Instantiate(ItemDescription, DescriptionParent) as GameObject;

           item.isInstatiated = true;
           Debug.Log(item.isInstatiated);
           
          


        
        //fügt den ItemNamen der ToggleGroup hinzu
          newToggle = IN.GetComponent<Toggle>(); 
          newToggle.group = toggleGroup;

          //fügt dem generierten Items einen Tag zu dieser dient der Funktionsweise des Toggles. mit der Funktion AssignToggle werden die Item Prefabs dem richtigen Toggle zugeordnet

          string itemTag = item.Itemtag;
          ID.tag = itemTag;

          InventoryToggle sn = IN.GetComponent<InventoryToggle>();
          sn.AssignToggle(itemTag);

        }}
    }
}
