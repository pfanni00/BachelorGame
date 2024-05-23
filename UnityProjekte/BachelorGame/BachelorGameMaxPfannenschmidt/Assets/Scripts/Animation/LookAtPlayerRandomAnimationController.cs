using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerRandomAnimation : MonoBehaviour
{
public Animator animator;

private float TimeUntilAnimationStart;
public float MinTimeUntilAnimationStart;
public float MaxTimeUntilAnimationStart;

private float timer;
private bool LookAtPlayerStateActive;
    private bool RandomAnimationStateActive;
    private int currentbaseState;

void Start()
{
    timer = 0.0f;
        TimeUntilAnimationStart = 14f;
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
        // Wenn die TimeUntilAnimationStart vorbei ist wird in den RandomAnimationState gewechselt und eine der Zufälligen Animationen Abgespielt 
        float aimAtPlayerAnimations = Random.Range(1, 5); // 1 bis 4 (einschließlich)
        animator.SetFloat("AimAtPlayerAnimations", aimAtPlayerAnimations);
            animator.SetInteger("BaseStates", 5);
    }

    if (RandomAnimationStateActive == true && IsAnimationFinished())
    {
         // Nachdem die Random Animation beendet ist wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimation start generiert

        animator.SetInteger("BaseStates", 4);
        timer = 0.0f; // Reset Timer
        TimeUntilAnimationStart = Random.Range(MinTimeUntilAnimationStart, MaxTimeUntilAnimationStart);
    }
}

bool IsAnimationFinished()
{
    // Überprüft, ob die aktuelle Animation in RandomAnimation beendet ist
    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    return stateInfo.IsName("AimRandomAnimation") && stateInfo.normalizedTime >= 1.0f;
}
}