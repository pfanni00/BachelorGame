using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeInteraction : MonoBehaviour, IInteractable {
    public GameObject HoverUi;
    public GameObject Player;

    public bool isUsabale;
    
    void Start()
    {
        isUsabale = true;
    }
   public void Interact()
    {
        if (isUsabale = true)
        {
        HUDControlls ic = Player.GetComponent<HUDControlls>();
        ic.openDialogsystem();  
        }    
    }

    public void HoverInteract()
    {
        if (isUsabale = true)
        {
        HoverUi.SetActive(true);
        }
    }

public void HoverInteractOFF()
    {
        HoverUi.SetActive(false);
    }

public void MakeUnusable()
{
isUsabale = false;
}
}

