using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EndeInteraction : MonoBehaviour, IInteractable
{   // Die Interaktion mit dem Collider auf dem dieses Script liegt leitet eines der Beiden Enden ein. 

    // Diese variable besttimmt ob Ending1 oder Ending2 geladen wird.
    public bool Ending1;
  
    // HoverUi wird im Editor zugewiesen
    public GameObject HoverUi;


    public void Interact()
    {
      // Je nach dem wie die variable Ending1 im editor definiert wurde wird nun eines der Enden geladen. 
            if (Ending1 == true)
            {
                GameManager.Instance.StartEnding1();
            }
            else if (Ending1 == false)
            {
                GameManager.Instance.StartEnding2();
            }    
    }

    public void HoverInteract()
    { 
        // HoverUi wird eingeblendet
        HoverUi.SetActive(true);
    }

    public void HoverInteractOFF()
    {
        // HoverUi wird ausgeblendet
        HoverUi.SetActive(false);
    }
}



