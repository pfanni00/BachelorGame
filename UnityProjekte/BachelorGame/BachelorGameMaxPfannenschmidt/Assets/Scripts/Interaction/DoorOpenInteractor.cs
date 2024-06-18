using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenInteractor : MonoBehaviour, IInteractable {
    // dieses Script managed die Interactionen mit Türen. 

    // gibt an ob Tür geöffnet ist. 
   private bool isOpen;

    // gibt an ob sich Tür bewegt. 
   private bool isRotating;

    // gibt die Gradzahl der Drehung beim Öffnen/Schließen der Tür an 
   public int rotationDegrees;  

    // Speichert Roation der Tür im geschlossenen Zustand.
   private Quaternion ClosedRotation;

    // Speichert Roation der Tür im Offenen zustand 
   private Quaternion OpenRotation;

    // HoverUI des Objectes
   public GameObject HoverUiOpen;
   public GameObject HoverUiClose;

    // geschwindigkeit der Öffung 
   public float rotationSpeed;

    // richtung der Öffungsrotation 
   public bool RotationDirection;

    // Occluder für Occlusion Culling 
   public OcclusionPortal doorOclusionPortal;

    
    void Start()
    {// Aktuelle Position wird in ClosedRotation gespeichert (Alle türen sind zu beginn des Spiels geschlossen) 
        ClosedRotation = transform.rotation;  

        // OpenRoation wird berechnet. je nach RotationDirection wird - oder +rotationDegrees gerechnet. So wird die Schwingrichtung der Tür invertiert.  
        if (RotationDirection == true)
        {
            OpenRotation = Quaternion.Euler(0, transform.eulerAngles.y + rotationDegrees, 0);  
        }else if (RotationDirection == false){
            OpenRotation = Quaternion.Euler(0, transform.eulerAngles.y - rotationDegrees, 0);  
        }

        // diese variable bestimmt ob Close oder OpenRotation die Zielrotation sind. Zu beginn sind alle Türen Zu
        isOpen = false;
    }

    void Update()
    {
        // wenn isRotating == true rotiert die Tür von Aktueller position zu einer der beiden zielpositionen. (Open/ClosedRotation) je nach der definition von isOpen. 
        if (isRotating == true)
        {
            if (isOpen == true)
            {// rotation speed bestimmt dabei die geschwindigkeit 
                transform.rotation = Quaternion.RotateTowards(transform.rotation, OpenRotation, rotationSpeed * Time.deltaTime);

                if (Quaternion.Angle(transform.rotation, OpenRotation) < 0.1f)
                {// tür stoppt rotation wenn zielRotation erreicht ist
                    transform.rotation = OpenRotation;
                    isRotating = false;
                }
            } else if (isOpen == false)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, ClosedRotation, rotationSpeed * Time.deltaTime);

                if (Quaternion.Angle(transform.rotation, ClosedRotation) < 0.1f)
                {// tür stoppt rotation wenn zielRotation erreicht ist
                    transform.rotation = ClosedRotation;
                    isRotating = false;
                }
            }
        }
    }

   public void Interact()
    {// interaction mit InteractObjecten ist nur möglich wenn InteractionEnabled im GameManager auf true gesetzt ist. 
    if (GameManager.Instance.InteractionEnabled == true)
     {
            // Interaction mit Tür nur möglich wenn sie sich nicht bewegt. 
        if(isRotating == false)
        {   // verbindung zu DoorAudioPlayer script wird hergestellt um audio Abzuspielen. 
            DoorAudioPlayer doorAudio = gameObject.GetComponent<DoorAudioPlayer>();
            
            // jenachdem ob Tür Offen/Geschlossen ist wird der korrekte sound abgespielt. 
            if(isOpen == false)
            {
            doorAudio.PlayOpenAudio();
            doorOclusionPortal.open = true;
            }else if (isOpen == true)
            {
            doorAudio.PlayCloseAudio();
            // Occlusion Culling wird eingeschalted falls tür geschlossen ist. 
            StartCoroutine(ActivateOcclusionCulling());
            }

          // Zielrotation der Tür wird invertiert. 
          isOpen = !isOpen;
          // Rotation wird gestarted
          isRotating = true;
          // HoverUI wird ausgeschalted
          HoverInteractOFF();
        }
    }
    }

    public void HoverInteract()
    {
        // wärend Tür sich bewegt ist HoverUI nicht verfügbar. 
    if(isRotating == false)
    {
            // je nachdem ob Tür Offen/Geschlossen ist wird korrektes UI element eingeblendet 
        if(isOpen == true)
        {
            HoverUiClose.SetActive(true);
        }else if(isOpen == false)
        {
            HoverUiOpen.SetActive(true);
        }
    }}

    public void HoverInteractOFF()
    {// HoverUI wird ausgeblendet. 
        HoverUiClose.SetActive(false);
        HoverUiOpen.SetActive(false);
    }

    private IEnumerator ActivateOcclusionCulling()
    {
        // nach 3 Sekunden (Dauer der Türschließungsanimation) wird das Occlusion Culling eingeschalted. So wird sichergestellt das die Tür wirklich zu ist bevor sie Objecte verdecken kann. 
    yield return new WaitForSeconds(3);
    doorOclusionPortal.open = false;

    }
    }



