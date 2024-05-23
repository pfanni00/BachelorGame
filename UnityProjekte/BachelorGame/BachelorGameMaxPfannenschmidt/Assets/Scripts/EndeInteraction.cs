using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EndeInteraction : MonoBehaviour, IInteractable
{

    public bool Ending1;
  
   
    public GameObject HoverUi;
  
    // Die Interaktion mit dem Collider auf dem dieses Script liegt leitet eines der Beiden Enden ein. 



    public void Interact()
    {
       // if(EndingAnimation.Instance.AnimationIsFinished == true) 
        //{
            if (Ending1 == true)
            {
                GameManager.Instance.StartEnding1();
            }
            else if (Ending1 == false)
            {
                GameManager.Instance.StartEnding2();
            }
        //}
    }

    public void HoverInteract()
    {
        //if (EndingAnimation.Instance.AnimationIsFinished == true)
        //{
            HoverUi.SetActive(true);
        //}
    }

    public void HoverInteractOFF()
    {
        HoverUi.SetActive(false);


    }
}



