using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName="New Item",menuName ="Item/Create new Item")]
public class Item : ScriptableObject
{

    // der title wird genutzt um das Entsprechende InventarListe Prefab zu finden. 
    public GameObject title;
    
    // isNew ist von start an activ und wenn ein item eingesammelt wird wird es auf false gesetzt
    public bool isNew;

    // isDeleted wird auf true gesetzt wenn ein Item aus dem Inventar gelöscht wird. 
    public bool isDeleted;

    //Itemtag wird genutzt um die Toggle Funktion des Objectes mit dem ToggleManager zu verknüpfen
    public string Itemtag;
}
