using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchlüsselPickup : MonoBehaviour
{
    public Item tagebuchGeschlossen;
    public Item tagebuchGeöffnet;
    
    void Pickup()
    {
        InventarManager.Instance.Add(tagebuchGeöffnet);
        InventarManager.Instance.Remove(tagebuchGeschlossen);
                Destroy(gameObject);

    }

    private void OnMouseDown()
    {
        Pickup();
    }
}