using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    
    void Pickup()
    {
        InventarManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
