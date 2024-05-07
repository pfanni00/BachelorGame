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
public  LayerMask InteractableLayer;

void Start()
    {
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
      

        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange, DefaultLayer))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                currentInteractable = interactObj;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentInteractable.Interact();
                }
                
                currentInteractable.HoverInteract();
                onHover = true;
        } else
            {
                if (onHover)
                {
                    currentInteractable.HoverInteractOFF();
                    onHover = false;
                    currentInteractable = null;
                }
            }


           
        }
    }
    }
