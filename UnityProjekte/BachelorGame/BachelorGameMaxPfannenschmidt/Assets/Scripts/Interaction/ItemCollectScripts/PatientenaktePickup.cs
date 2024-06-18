

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientenaktePickup : MonoBehaviour, IInteractable
{
    // Dieses Script managed das aufheben der ZerissenenZettel bzw Patientenakte Items.

    // HoverUi wird beim ansehen des Items eingeblendet.
    public GameObject HoverUi;




    public void Interact()
    {
        if (GameManager.Instance.InteractionEnabled == true)

        {// wird ein ZerissenerZettel Aufgehoben, verwaltet das Script PatientenakteLogic, welches Item angezeigt wird.
            PatientenakteLogic.Instance.PatientenakteStates();
            // game Object wird gelöscht
            Destroy(gameObject);
        }
    }

    public void HoverInteract()
    {
        // Hover UI wir eingeblendet 
        HoverUi.SetActive(true);
    }

    public void HoverInteractOFF()
    {
        // Hover UI wir ausgeblendet
        HoverUi.SetActive(false);
    }
}

