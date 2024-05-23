using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerRandomAnimation : MonoBehaviour
{
public Animator animator;

public float TimeUntilAnimationStart = 5.0f; // Zeit in Sekunden, die der LookAtPlayer-State dauern soll

private float timer;
private bool LookAtPlayerStateActive;
    private bool RandomAnimationStateActive;
    private int currentbaseState;

void Start()
{
    timer = 0.0f;
       // LookAtPlayerStateActive = true;
    //animator.SetInteger("baseState", 1); // Startet im LookAtPlayer-State
}

void Update()
{
    timer += Time.deltaTime;
    
       int currentbaseState = animator.GetInteger("BaseStates");
    if (currentbaseState == 4)
        {
            LookAtPlayerStateActive = true;
            RandomAnimationStateActive = false;
        } else if (currentbaseState == 5) 
            {
            LookAtPlayerStateActive = false;
            RandomAnimationStateActive = true;
        } else
        {
            LookAtPlayerStateActive = false;
            RandomAnimationStateActive = false;
            timer = 0.0f;
        }
        
    if (LookAtPlayerStateActive == true && timer >= TimeUntilAnimationStart)
    {
        // Wechsel zu RandomAnimation
        //LookAtPlayerStateActive = false;
       // RandomAnimationStateActive = true;
        float aimAtPlayerAnimations = Random.Range(1, 5); // 1 bis 4 (einschließlich)
        animator.SetFloat("AimAtPlayerAnimations", aimAtPlayerAnimations);
            animator.SetInteger("BaseStates", 5);

            //timer = 0.0f; // Reset Timer
    }

    if (RandomAnimationStateActive == true && IsAnimationFinished())
    {
            // Wechsel zurück zu LookAtPlayer
        //LookAtPlayerStateActive = true;
        animator.SetInteger("BaseStates", 4);
        timer = 0.0f; // Reset Timer
    }
}

bool IsAnimationFinished()
{
    // Überprüft, ob die aktuelle Animation in RandomAnimation beendet ist
    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    return stateInfo.IsName("AimRandomAnimation") && stateInfo.normalizedTime >= 1.0f;
}
}