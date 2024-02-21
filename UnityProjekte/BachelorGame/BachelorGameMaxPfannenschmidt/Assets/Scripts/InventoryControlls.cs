using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControlls : MonoBehaviour
{
    public bool Inventroryisuseabale;
    public bool InventoryisOpen;
    public GameObject ItemUI;
    // Start is called before the first frame update
    void Start()
    {
        Inventroryisuseabale = true;
        closeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
         Debug.Log("INVENTAR");
            if (InventoryisOpen == false)
            {
                openInventory();
            } 
            else if  (InventoryisOpen == true)
            {
                closeInventory();
            }
        }
    }
    private void closeInventory()
    {
        InventoryisOpen = false;
        ItemUI.SetActive(false);
    }
    
    private void openInventory()
    {
        InventoryisOpen = true;
        ItemUI.SetActive(true);
    }
}
