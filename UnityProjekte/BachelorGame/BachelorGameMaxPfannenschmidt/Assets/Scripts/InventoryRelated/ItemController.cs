using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item Item;

// stellt sicher das Items beim Start des Spiels als nicht aufgehoben Gelten
    private void Awake()
{
    Item.isNew = true;
    Item.isDeleted = false;
}

    public void Select()
    {
        Item.isNew = false;
    }

}

