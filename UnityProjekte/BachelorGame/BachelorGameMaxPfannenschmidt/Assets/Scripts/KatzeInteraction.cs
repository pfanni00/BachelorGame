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

    void Update()
    {
        if (DialogAudioController.Instance.AudioisActive == true || DialogsystemManager.Instance.AlldialogisFinished == true)
        {
            MakeUnusable();
        }else MakeUsable();
       
    }
   public void Interact()
    {
        if (isUsabale == true)
        {
        HUDControlls ic = Player.GetComponent<HUDControlls>();
        ic.openDialogsystem();  
        }    
    }

    public void HoverInteract()
    {
        if (isUsabale == true)
        {
        HoverUi.SetActive(true);
        }
    }

public void HoverInteractOFF()
    {
        HoverUi.SetActive(false);
    }

private void MakeUnusable()
{
isUsabale = false;
HoverInteractOFF();
}
private void MakeUsable()
{
isUsabale = true;
}
}

