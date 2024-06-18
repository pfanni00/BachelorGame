using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeInteraction : MonoBehaviour, IInteractable {
    //Dieses Script managed die Interaction mit der Katze

    // HoverUI des Objectes
    public GameObject HoverUi;

    // referenz zum Player
    public GameObject Player;

    // referenz zum dialogTrigger (Collider in welchem der Spieler stehen muss um mit der Katze Interagieren zu können.
    public GameObject dialogTrigger;

    // diese variable zeigt an ob der Spieler den dialogTrigger berührt
    private bool triggerActive;

    // diese variable zeigt ob der Spieler bereits mit der Katze interagiert hat. 
    public bool HasBeenInteracted;

    // diese variable bestimmt ob die Interaktion mit der Katze möglich ist. 
    public bool isUsabale;
    
    void Start()
    {      
        // interaktion ist zum Start möglich 
        isUsabale = true;
    }

    void Update()
    {
        // verbindung zum DialogTrigger wird hergestellt. 
        DialogTrigger dt = dialogTrigger.GetComponent<DialogTrigger>();
        //TriggerActive variable des dialog triggers wird local in triggerActive gespeichert. 
        triggerActive = dt.TriggerActive;

        // wenn noch nicht alle Dialogoptionen Abgespielt wurden findet abfrage statt die bestimmt ob Interaktion möglich ist.
        if (DialogsystemManager.Instance.AlldialogisFinished == false)

        {   //Wenn audio Abgespielt wird/ der Spieler nicht den DialogTrigger berührt/ oder DialogsystemManager bestimmt dass Dialogsystem nicht nutzbar ist, ist Interaktion nicht möglich 
            if (DialogAudioController.Instance.AudioisActive == true || DialogsystemManager.Instance.DialogsystemIsUsabale == false || triggerActive == false)
            {
                MakeUnusable();
            }
            // trifft keine der konditionen zu und der Spieler berührt den Dialog Trigger ist Interaktion möglich 
            else if (triggerActive == true)
            {
                MakeUsable();
            }
        }
        // wenn bereits alle dialogoptionen abgespielt wurden ist Interaktion nicht mehr möglich 
        else MakeUnusable();
    }



   public void Interact()
    {// interaction mit InteractObjecten ist nur möglich wenn InteractionEnabled im GameManager auf true gesetzt ist. 
        if (GameManager.Instance.InteractionEnabled == true)
        {
            if (isUsabale == true)
            {
                // wenn der Spieler zum ersten mal mit der Katze interagiert wird der Initiale Dialog Gestarted
                if(HasBeenInteracted == false)
                {
                    HasBeenInteracted = true;
                    DialogAudioController.Instance.StartFirstDialog();
                }
                // Bei Interaktion wird Dialogsystem UI wird und die AimAtPlayer Animation gestated
                HUDControlls.Instance.openDialogsystem();
                KatzeAnimationsController.Instance.SetState(4);
            }
        }    
    }

    public void HoverInteract()
    {
        if (isUsabale == true)
        {
        // wenn nutzbar wird HoverUi eingeblendet
        HoverUi.SetActive(true);
        }

    }

    public void HoverInteractOFF()
    {
        // HoverUi wird ausgeblendet
        HoverUi.SetActive(false);
    }

    // Funktion um Interaktion mit Katze abzuschalten
    private void MakeUnusable()
    {
        isUsabale = false;

        // HoverUi wird ausgeschaltet
        HoverInteractOFF();
    }

    // Funktion um Interaktion mit Katze einzuschalten
    private void MakeUsable()
    {
        isUsabale = true;
    }
}

