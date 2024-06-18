using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToIdle : StateMachineBehaviour
{
    //Dieses Script l�sst den AnimationController wiedr zum Idle state zur�ckehren nachdem die Animation abgeschlossen ist

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        KatzeAnimationsController.Instance.currentState = 4;
        KatzeAnimationsController.Instance.IdleAnimationState();
    }

    
}
