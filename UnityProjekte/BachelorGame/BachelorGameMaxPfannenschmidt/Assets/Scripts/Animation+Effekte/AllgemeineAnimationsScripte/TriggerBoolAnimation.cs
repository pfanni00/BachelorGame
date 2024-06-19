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
        //boolVariable wird im animator auf true gesetzet
        if (Enter_Exit == true)
        {
            animator.SetBool(boolVariable, boolVariableValue);
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //boolVariable wird im animator auf true gesetzet
        if (Enter_Exit == false)
        {
            animator.SetBool(boolVariable, boolVariableValue);
        }
    }
}
