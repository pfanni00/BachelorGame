using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
    public void Interact();
    public void HoverInteract();

    public void HoverInteractOFF();
}
public class Interactor : MonoBehaviour
{
    //    Dieses Script managed das interagieren mit Objecten im Level wie Türen oder Items 
    public Transform InteractorSource;
    public float InteractRange;
    private IInteractable currentInteractable; // Referenz auf das aktuelle IInteractable-Objekt
    private bool onHover;
    private bool InteractActivated;
    public LayerMask DefaultLayer;
    //public LayerMask InteractableLayer;

    void Start()
    {
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);


        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange, DefaultLayer))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

            // prüfung of hitObject Interactiv ist
            if (hitObject.TryGetComponent(out IInteractable interactObj))
            {  //Hover Text wird eingeblendet
    	        
            if (!onHover || currentInteractable == null)
                {   //Hover wert wird gespeichert
                    onHover = true;
                    Debug.Log(onHover);
                    interactObj.HoverInteract();
                    currentInteractable = interactObj;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //mit object kann interagiert werden
                    interactObj.Interact();
                }

                } 
            
            else if(onHover || currentInteractable != null)
                {
                    currentInteractable?.HoverInteractOFF();
                    Debug.Log(onHover);
                    interactObj.HoverInteract();
                    currentInteractable = interactObj;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //mit object kann interagiert werden
                    interactObj.Interact();
                }

                }
            }
            else
            {
                // Keine Interaktion, falls es sich um kein interaktives Objekt handelt
                if (onHover)
                {
                    currentInteractable?.HoverInteractOFF();
                    onHover = false;
                    Debug.Log(onHover);

                    currentInteractable = null;
                }
            }
        }
        else
        {
            // Keine Interaktion, falls kein Object Gefunden wird 
            if (onHover)
            {
                currentInteractable?.HoverInteractOFF();
                onHover = false;
                Debug.Log(onHover);

                currentInteractable = null;
            }
        }
    }
}