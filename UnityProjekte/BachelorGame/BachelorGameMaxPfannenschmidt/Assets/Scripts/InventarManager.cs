using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

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



    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void Add(Item item)
    {
        Items.Add(item);

       ListItems();


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
            Debug.Log(ItemName);
            Debug.Log(ItemDescription);
          //  ItemText = item.text;
           // ItemModel = item.model;

            GameObject IN = Instantiate(ItemName, NameParent) as GameObject;
           // IN.transform.parent = GameObject.Find("InventarNamePosition").transform;

            GameObject ID = Instantiate(ItemDescription, DescriptionParent) as GameObject;
           // ID.transform.parent = GameObject.Find("ItemBeschreibungPosition").transform; 
           item.isInstatiated = true;
           Debug.Log(item.isInstatiated);

        }}
    }
}
