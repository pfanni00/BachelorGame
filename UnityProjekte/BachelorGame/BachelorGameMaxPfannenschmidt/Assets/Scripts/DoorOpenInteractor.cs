using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenInteractor : MonoBehaviour, IInteractable {
   //public GameObject Door;
   private bool isOpen;
   private bool isRotating;
   public Quaternion ClosedRotation;    
   public Quaternion OpenRotation;
   private Quaternion targetRotation;
   public GameObject HoverUiOpen;
   public GameObject HoverUiClose;
   public float rotationSpeed;

   
    
    void Start()
    {      // triggerActive = dialogTrigger.GetComponent<DialogTrigger>().TriggerActive;
    isOpen = false;

    }

    void Update()
    {
           if (isOpen == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, OpenRotation, rotationSpeed * Time.deltaTime);
        }else if (isOpen == false)
        {
             transform.rotation = Quaternion.RotateTowards(transform.rotation, ClosedRotation, rotationSpeed * Time.deltaTime);

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
        //HoverUi.SetActive(true);
        
    }

    public void HoverInteractOFF()
    {
        HoverUiClose.SetActive(false);
        HoverUiOpen.SetActive(false);

    }

    }



