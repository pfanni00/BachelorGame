using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchubladeInteraction : MonoBehaviour, IInteractable {

   private bool isOpen;
   //private bool isRotating;
   //public int rotationDegrees;  
  // public GameObject ClosedPosition;
   //public GameObject OpenPosition;
   //private Transform target;
   public float OpenZ;
   public float CloseZ;
   //public GameObject Schublade;
   public GameObject HoverUiOpen;
   public GameObject HoverUiClose;
   private Vector3 targetPosition;
   public float speed;
   //public bool RotationDirection;

   // dieses Script rotiert ein GameObject beim Interagieren durch den Spieler. Der Grad der Rotation kann mit int rotatingDegrees bestimmt werden. Mit rotationSpeed wird die Geschwindigkeit der Rotation bestimmt und mit RotationDirection die Richtung
    
    void Start()
    {
        
        isOpen = false;
    }

    void Update()
    {
     
        Vector3 currentPosition = transform.localPosition;

        if(isOpen == true)
        {
         targetPosition = new Vector3(currentPosition.x, currentPosition.y, OpenZ);
        }
        else if(isOpen == false)
        {
         targetPosition = new Vector3(currentPosition.x, currentPosition.y, CloseZ);
  
        }
        // Create a target position vector, changing only the z component

        // Calculate the step size based on speed and frame time
        float step = speed * Time.deltaTime;

        // Move towards the target z position
        transform.localPosition = Vector3.MoveTowards(currentPosition, targetPosition, step);

        // Optionally check if the target z position is reached
        if (transform.localPosition.z == OpenZ)
        {
          //  Debug.Log("Reached target Z position");
        }
    }
 
    
   public void Interact()
    {
          isOpen = !isOpen;
          HoverInteractOFF();
    }

    public void HoverInteract()
    {
       
        if(isOpen == true)
        {
            HoverUiClose.SetActive(true);
        }else if(isOpen == false)
        {
            HoverUiOpen.SetActive(true);
        }
    }

    public void HoverInteractOFF()
    {
        HoverUiClose.SetActive(false);
        HoverUiOpen.SetActive(false);

    }
    }



