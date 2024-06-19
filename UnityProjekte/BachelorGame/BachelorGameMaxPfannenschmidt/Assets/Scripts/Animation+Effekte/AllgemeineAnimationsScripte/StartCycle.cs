using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCycle : StateMachineBehaviour
{
    // dieses Script setzt nach dem Start einer Animation den Wert wieder zurück auf den eingegebenen baseState 
    public int baseStates;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("BaseStates", baseStates);
    }

    
}
