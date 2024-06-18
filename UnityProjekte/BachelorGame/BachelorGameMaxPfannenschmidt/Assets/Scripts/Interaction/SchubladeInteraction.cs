using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchubladeInteraction : MonoBehaviour, IInteractable {

    // gibt an ob schublade Geöffnet ist. 
    private bool isOpen;
 
    // Bewegung findet auf Z achse statt
    // Z transformation für offenen zustand
    public float OpenZ;
    
    public float CloseZ;
    // Z tranformation für geschlossenen zustand
   public GameObject HoverUiOpen;
   public GameObject HoverUiClose;
   private Vector3 targetPosition;
   public float speed;

   // dieses Script Managed die Interaktion mit Schubladen. 
    
    void Start()
    {
        // diese variable bestimmt ob OpenZ oder CloseZ die ziel Transform.z sind.Zu beginn ist die Schublade zu

        isOpen = false;
    }

    void Update()
    {
        // aktuelle position wird bestimmt 
        Vector3 currentPosition = transform.localPosition;

        // Je nach isOpen wert wird nun die zielposition als Vector3 berechnet
        if(isOpen == true)
        {
         targetPosition = new Vector3(currentPosition.x, currentPosition.y, OpenZ);
        }
        else if(isOpen == false)
        {
         targetPosition = new Vector3(currentPosition.x, currentPosition.y, CloseZ);
  
        }

        // step size (bewegung pro secunde) wird ausgerechnet. speed bestimmt dabei die geschwindigkeit
        float step = speed * Time.deltaTime;

        // bewegung zu zielposition wird gestartet 
        transform.localPosition = Vector3.MoveTowards(currentPosition, targetPosition, step);

       
    }
 
    
   public void Interact()
    {// interaction mit InteractObjecten ist nur möglich wenn InteractionEnabled im GameManager auf true gesetzt ist. 
        if (GameManager.Instance.InteractionEnabled == true)
        {
            // verbindung zum AudioPlayer wird hergestellt
            DoorAudioPlayer doorAudio = gameObject.GetComponent<DoorAudioPlayer>();
            
            // correkter Soundeffekt wird abgespielt je nach status (offen/geschlossen)
            if(isOpen == false)
            {
            doorAudio.PlayOpenAudio();
            }else if (isOpen == true)
            {
            doorAudio.PlayCloseAudio();
            }

            // ziel z Transformation wird invertiert
          isOpen = !isOpen;
            // Hover UI wird ausgeblendet
          HoverInteractOFF();
        }
        
    }

    public void HoverInteract()
    {  // wärend Tür sich bewegt ist HoverUI nicht verfügbar. 

        // je nachdem ob Schublade Offen/Geschlossen ist wird korrektes UI element eingeblendet 

        if (isOpen == true)
        {
            HoverUiClose.SetActive(true);
        }else if(isOpen == false)
        {
            HoverUiOpen.SetActive(true);
        }
    }

    public void HoverInteractOFF()
    {
        // Hover UI wird ausgeblendet
        HoverUiClose.SetActive(false);
        HoverUiOpen.SetActive(false);

    }
    }



