using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName="New Item",menuName ="Item/Create new Item")]
public class Item : ScriptableObject
{
    public int id;
    public GameObject name;
    public GameObject description;
    public GameObject text;
    public GameObject model;
}
