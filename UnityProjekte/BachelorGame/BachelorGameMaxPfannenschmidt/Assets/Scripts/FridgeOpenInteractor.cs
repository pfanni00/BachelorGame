using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeOpenInteractor : MonoBehaviour, IInteractable {

   private bool isOpen;
   private bool isRotating;
   public int rotationDegrees;  
   private Quaternion ClosedRotation;
   private Quaternion OpenRotation;
   public GameObject HoverUiOpen;
   public GameObject HoverUiClose;
   public float rotationSpeed;
   public bool RotationDirection;
  // private GameObject doorAudioPlayer;

   // dieses Script rotiert ein GameObject beim Interagieren durch den Spieler. Der Grad der Rotation kann mit int rotatingDegrees bestimmt werden. Mit rotationSpeed wird die Geschwindigkeit der Rotation bestimmt und mit RotationDirection die Richtung
    
    void Start()
    {
        ClosedRotation = transform.rotation;  

        if (RotationDirection == true)
        {
            OpenRotation = Quaternion.Euler(0, transform.eulerAngles.y + rotationDegrees, 0);  
        }else if (RotationDirection == false){
            OpenRotation = Quaternion.Euler(0, transform.eulerAngles.y - rotationDegrees, 0);  
        }
        isOpen = false;
    }

    void Update()
    {
        if (isRotating == true)
        {
            if (isOpen == true)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, OpenRotation, rotationSpeed * Time.deltaTime);

                if (Quaternion.Angle(transform.rotation, OpenRotation) < 0.1f)
                {
                    transform.rotation = OpenRotation;
                    isRotating = false;
                }
            } else if (isOpen == false)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, ClosedRotation, rotationSpeed * Time.deltaTime);

                if (Quaternion.Angle(transform.rotation, ClosedRotation) < 0.1f)
                {
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
        
        //Wenn die Kühlschranktür geöffnet wird wird der Entsprechende Sound Abgespielt und der loop für das Rauschen des Kühlschranks gestartet.
        DoorAudioPlayer doorAudio = gameObject.GetComponent<DoorAudioPlayer>();
        AudioLoopPlayer audioloop = gameObject.GetComponent<AudioLoopPlayer>();
        if(isOpen == false)
        {
        audioloop.Playaudio();
        doorAudio.PlayOpenAudio();
        }else if (isOpen == true)
        {
        audioloop.StopAudio();
        doorAudio.PlayCloseAudio();
        }

    
          isOpen = !isOpen;
          isRotating = true;
          HoverInteractOFF();
    }
    }

    public void HoverInteract()
    {
    if(isRotating == false)
    {
        if(isOpen == true)
        {
            HoverUiClose.SetActive(true);
        }else if(isOpen == false)
        {
            HoverUiOpen.SetActive(true);
        }
    }}

    public void HoverInteractOFF()
    {
        HoverUiClose.SetActive(false);
        HoverUiOpen.SetActive(false);
    }
    }


