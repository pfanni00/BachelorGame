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
    //    Dieses Script managed das interagieren mit Objecten im Level wie Türen, Items oder auch der Katze
    // Hier wird die MainCamera eingefügt. Dient als ursprung für den Ray der nach interaktableObjects sucht. 
    public Transform InteractorSource;

    // die reichweite in der InteractableObjects angezeigt werden. 
    public float InteractRange;
    private IInteractable currentInteractable; // Referenz auf das aktuelle IInteractable-Objekt
    
    // Bool variable die feststellt ob ein Object angesehen wird. 
    private bool onHover;

    // 
    //private bool InteractActivated;
    // LayerMask für alle Objecte die vom Raycast erfasst werden können 
    public LayerMask DefaultLayer;


    void Update()
    {
        // neuer Ray der von der MainCamera aus nach vorne geworfen wird. 
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

        // wenn der Ray auf einen Collider im DefaultLayer trifft wird es als GameObject und in hitObject gespeichert.  
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange, DefaultLayer))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

        // prüfung of hitObject Interactiv ist
        if (hitObject.TryGetComponent(out IInteractable interactObj))
        {  //wenn Interactiv wird Hover Text eingeblendet. Hovertext wird nur dann eingeblendet wenn nicht bereits ein anderes interactObj angewählt ist. So wird verhindert das mehrere InteractableObj gleichzeitig ausgewählt werden.  
    	        
            if (!onHover || currentInteractable == null)
                {   //Hover wert wird gespeichert 
                    onHover = true;
                    //HoverInteract() wird in den jeweiligen Interact[Object] scripts weiter definiert. 
                    interactObj.HoverInteract();
                    currentInteractable = interactObj;

                // mit E kann mit Object interagiert werden nachdem onHover selectiert wird. 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //mit object kann interagiert werden
                    interactObj.Interact();
                }
            } 
            
            // wenn bereits ein Interactable selectiert ist und nun ein neues erfasst wird, wird zunächst das Alte currentInteractable abgeschaltet und dann das neue Object gespeichert. 
            else if(onHover || currentInteractable != null)
            {
                    currentInteractable?.HoverInteractOFF();
                    //HoverInteract() wird in den jeweiligen Interact[Object] scripts weiter definiert. 
                    interactObj.HoverInteract();
                    currentInteractable = interactObj;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Interact() wird in den jeweiligen Interact[Object] scripts weiter definiert. 
                    interactObj.Interact();
                }
            }
        }
            else
            {
                // Keine Interaktion, falls es sich um kein interaktives Objekt handelt
                if (onHover)
                {
                    // Hover Text wird wieder ausgeblendet. 
                    currentInteractable?.HoverInteractOFF();
                    onHover = false;
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
                currentInteractable = null;
            }
        }
    }
}