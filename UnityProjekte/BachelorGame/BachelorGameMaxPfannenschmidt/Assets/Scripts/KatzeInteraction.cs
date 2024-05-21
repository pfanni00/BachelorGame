using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeInteraction : MonoBehaviour, IInteractable {
    public GameObject HoverUi;
    public GameObject Player;
    public GameObject dialogTrigger;
    private bool triggerActive;
    private bool HasBeenInteracted;
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

        if (DialogsystemManager.Instance.AlldialogisFinished == false)
        {
            if (DialogAudioController.Instance.AudioisActive == true || DialogsystemManager.Instance.DialogsystemIsUsabale == false || triggerActive == false)
            {
                MakeUnusable();
            }
            else if (triggerActive == true)
            {
                MakeUsable();
            }
        } else MakeUnusable();
    }
   public void Interact()
    {
        if (isUsabale == true)
        {
            // wenn der Spieler zum ersten mal mit der Katze interagiert wird der Initiale Dialog Gestarted
        if(HasBeenInteracted == false)
            {
                HasBeenInteracted = true;
                DialogAudioController.Instance.StartFirstDialog();

            }

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

