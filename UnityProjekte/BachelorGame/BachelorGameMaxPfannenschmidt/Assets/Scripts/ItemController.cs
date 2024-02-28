using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item Item;
    //private GameObject ItemDescription;

// stellt sicher das Items beim Start des Spiels als nicht aufgehoben Gelten
    private void Awake()
{
   // Item.isSelected = false;
    Item.isInstatiated = false;

   // ItemDescription = Item.description;
}
/*
public void SelectItem()
{
    
    ItemDescription.SetActive(true);

    Item.isSelected = true;
}
*/
public void DeselectItem()
{
   // Item.isSelected = false;
    Item.description.SetActive(false);

}
   /* private void Update()
{
    if(Item.isSelected == false)
    {
        Item.description.SetActive(false);
       // Item.text.SetActive(false);
       // Item.model.SetActive(false);
    }else if (Item.isSelected == true)
    {
        Item.description.SetActive(true);
      //  Item.text.SetActive(true);
      //  Item.model.SetActive(true);
    }
}*/
}

