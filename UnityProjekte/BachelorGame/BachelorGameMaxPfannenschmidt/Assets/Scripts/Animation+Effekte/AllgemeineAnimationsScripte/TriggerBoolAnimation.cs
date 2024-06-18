using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoolAnimation : StateMachineBehaviour
{
    // Mit diesem Script können bool Parameter im Animator durch OnStateExit oder OnStateEnter verändert werden 

    public string boolVariable;
    // bei true = enter bei false = Exit 
    public bool Enter_Exit;
    // bei true wird die boolVariable auf true gesetzt bei false auf false 
    public bool boolVariableValue;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Enter_Exit == true)
        {
            animator.SetBool(boolVariable, boolVariableValue);
        }
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Enter_Exit == false)
        {
            animator.SetBool(boolVariable, boolVariableValue);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
