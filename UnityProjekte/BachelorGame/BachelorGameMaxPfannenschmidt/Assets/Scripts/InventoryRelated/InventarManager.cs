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

    private GameObject ItemName;

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
        if (item.isInstatiated == false)
        {
        Items.Add(item);

        ListItems();
       // toggleGroupController sn = NameParent.GetComponent<toggleGroupController>();
       // sn.AddToggle();
        }
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

           // ItemModel = item.model;

            GameObject IN = Instantiate(ItemName, NameParent) as GameObject;


           item.isInstatiated = true;
           
          


        
        //fügt den ItemNamen der ToggleGroup hinzu
          newToggle = IN.GetComponent<Toggle>(); 
          newToggle.group = toggleGroup;
          newToggle.isOn = true;

          

        }}
    }
}
