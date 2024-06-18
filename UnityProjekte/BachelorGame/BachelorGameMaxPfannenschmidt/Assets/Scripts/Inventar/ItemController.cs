using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Dieses Script speichert das Item Object in dem entsprechenden ItemModel Prefab. Auﬂerdem werden die variablen isNew und isDeleted zum start auf den richtigen wert gesetzt
    public Item Item;

// stellt sicher das Items beim Start des Spiels als nicht aufgehoben Gelten
    private void Awake()
{
    Item.isNew = true;
    Item.isDeleted = false;
}

}

