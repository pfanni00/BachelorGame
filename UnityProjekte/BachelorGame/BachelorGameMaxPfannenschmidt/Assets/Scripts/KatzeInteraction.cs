using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeInteraction : MonoBehaviour, IInteractable {
    public GameObject HoverUi;
    public GameObject Player;
    public GameObject dialogTrigger;
    private bool triggerActive;

    public bool isUsabale;
    
    void Start()
    {      // triggerActive = dialogTrigger.GetComponent<DialogTrigger>().TriggerActive;

      
        isUsabale = true;
        //Debug.Log(triggerActive);
    }

    void Update()
    {
        DialogTrigger dt = dialogTrigger.GetComponent<DialogTrigger>();
        triggerActive = dt.TriggerActive;  

        if (DialogAudioController.Instance.AudioisActive == true || DialogsystemManager.Instance.AlldialogisFinished == true || triggerActive == false)
        {
            MakeUnusable();
        }else if (triggerActive == true)
        {
            MakeUsable();
        }
       
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

