using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeAnimationsController : MonoBehaviour
{
    Animator animator;
    private int baseStates;// = BaseStates im Animator
    public GameObject dialogTriggerObj;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {   //das script dialogTrigger wird untersucht
        DialogTrigger dialogTrigger = dialogTriggerObj.GetComponent<DialogTrigger>();
        Debug.Log(dialogTrigger.TriggerActive);
        //wenn der Spieler in den Dialog Trigger Collider tritt sieht die Katze zu ihm
        if (dialogTrigger.TriggerActive == true)
        {
            baseStates = 4;
        }
        else
        {
            baseStates = 1;
        }

        animator.SetInteger("BaseStates", baseStates);
    }
}
