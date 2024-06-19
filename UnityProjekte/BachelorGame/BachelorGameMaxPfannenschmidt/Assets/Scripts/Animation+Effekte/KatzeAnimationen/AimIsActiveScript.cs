using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimIsActiveScript : StateMachineBehaviour
{// dieses Script ändert die variable AimisActive im CatAnimator auf True / False beim Enter / Exit des LookatPlayer States 


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AimisActive", true);
    }

   
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AimisActive", false);
    }

 
}
