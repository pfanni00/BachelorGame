using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InventarManager : MonoBehaviour
{
    public static InventarManager Instance;
    public List<Item> Items = new List<Item>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
}
