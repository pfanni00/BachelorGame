using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenInteractor : MonoBehaviour, IInteractable {
   //public GameObject Door;
   private bool isOpen;
   public Quaternion ClosedRotation;    
   public Quaternion OpenRotation;
    public GameObject HoverUi;

   
    
    void Start()
    {      // triggerActive = dialogTrigger.GetComponent<DialogTrigger>().TriggerActive;
    isOpen = false;
    }

    void Update()
    {
       
       
    }
   public void Interact()
    {
        if (isOpen == false)
        {
        transform.rotation = OpenRotation;
        }else if (isOpen == true)
        {
        transform.rotation = ClosedRotation;
        }
    }

    public void HoverInteract()
    {
       
        
        HoverUi.SetActive(true);
        
    }

    public void HoverInteractOFF()
    {
        HoverUi.SetActive(false);
    }

    }



