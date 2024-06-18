using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeOpenInteractor : MonoBehaviour, IInteractable {
    // Dieses Script managed die Interaktion mit der Kühlschranktür. Es funktioniert Identisch zu DoorOpenInteractor nur das Abspielen der Audio unterscheidet sich

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

   // dieses Script rotiert ein GameObject beim Interagieren durch den Spieler. Der Grad der Rotation kann mit int rotatingDegrees bestimmt werden. Mit rotationSpeed wird die Geschwindigkeit der Rotation bestimmt und mit RotationDirection die Richtung
    
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
            {
                // rotation speed bestimmt dabei die geschwindigkeit 
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
    {
    if(isRotating == false)
    {   
        
        //verbindung zu den AudioScripts wird hergestellt.
        DoorAudioPlayer doorAudio = gameObject.GetComponent<DoorAudioPlayer>();
        AudioLoopPlayer audioloop = gameObject.GetComponent<AudioLoopPlayer>();

        if(isOpen == false)
        {
        //Wenn die Kühlschranktür geöffnet wird wird der Entsprechende Sound Abgespielt und der loop für das Rauschen des Kühlschranks gestartet.
        audioloop.Playaudio();
        doorAudio.PlayOpenAudio();
        }else if (isOpen == true)
        {
        //wird tür geschlossen stoppt der Loop und entsprechendes Audio wird abgespielt
        audioloop.StopAudio();
        doorAudio.PlayCloseAudio();
        }

            // Zielrotation der Tür wird invertiert. 
            isOpen = !isOpen;
            // Rotation wird gestarted
            isRotating = true;
            // HoverUI wird ausgeblendet
            HoverInteractOFF();
    }
    }

    public void HoverInteract()
    {
        // wärend Tür sich bewegt ist HoverUI nicht verfügbar. 
        if (isRotating == false)
        {
            // je nachdem ob Tür Offen/Geschlossen ist wird korrektes UI element eingeblendet 
        if (isOpen == true)
            {
                HoverUiClose.SetActive(true);
            }
        else if(isOpen == false)
            {
                HoverUiOpen.SetActive(true);
            }
    }
    }

    public void HoverInteractOFF()
    {// HoverUI wird ausgeblendet. 
        HoverUiClose.SetActive(false);
        HoverUiOpen.SetActive(false);
    }
    }



