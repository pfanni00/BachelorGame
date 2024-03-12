using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName="New Item",menuName ="Item/Create new Item")]
public class Item : ScriptableObject
{
    public int id;
    public GameObject title;
    //public GameObject description;
    //public GameObject text;
    //public GameObject model;
    public bool isInstatiated;
   // public bool isSelected;

    //public string Itemtag;
}
