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
    //public GameObject titleInstantiated = null;
    public bool isNew;
    public bool isDeleted;
    public string Itemtag;
    public GameObject hoverTitle;
}
