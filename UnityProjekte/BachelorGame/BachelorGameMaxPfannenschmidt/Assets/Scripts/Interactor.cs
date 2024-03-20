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

public  LayerMask InteractableLayer;

void Start()
    {
     //   onHover = false
    }
//Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
    // Update is called once per frame
    void Update()
    {          
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Input.GetKeyDown(KeyCode.E)) {
           // Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange, InteractableLayer)) {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
        }


  if (Physics.Raycast(r, out RaycastHit hoverinfo, InteractRange, InteractableLayer)) {
            if (hoverinfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                Debug.Log("HIT");
                interactObj.HoverInteract();
                if (!onHover) {
                    onHover = true;
                    currentInteractable = interactObj;
                }
            }
        }
        else {
            if (onHover) {
                currentInteractable.HoverInteractOFF();
                onHover = false;
                currentInteractable = null;
            }
        }
    }
}