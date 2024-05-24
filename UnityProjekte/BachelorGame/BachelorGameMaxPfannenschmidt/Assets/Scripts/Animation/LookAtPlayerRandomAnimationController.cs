using System.Collections;
using UnityEngine;

public class LookAtPlayerRandomAnimation : MonoBehaviour
{
public Animator animator;
    [SerializeField]

    private float TimeUntilAnimationStart;
public float MinTimeUntilAnimationStart;
public float MaxTimeUntilAnimationStart;
    [SerializeField]

    private float TimeUntilFacialStart;
    public float MinTimeUntilFacialStart;
    public float MaxTimeUntilFacialStart;
    [SerializeField]

    private float timer;
    [SerializeField]
private float timerFace;
    [SerializeField]
    private bool LookAtPlayerStateActive;
    [SerializeField]
    private bool RandomAnimationStateActive;
    [SerializeField]
    private bool RandomFacialAnimationState;
private int currentbaseState;

void Start()
{
    timer = 0.0f;
    timerFace = 0.0f;
    TimeUntilAnimationStart = 14f;
        TimeUntilFacialStart = 10f;
}

void Update()
{
        // Wenn gerade keine GesichtsAnimation Gespielt wird läuft der Timer für die 
    if (LookAtPlayerStateActive == true )
        {
            timer += Time.deltaTime;
            timerFace += Time.deltaTime;

        }

      
    
       int currentbaseState = animator.GetInteger("BaseStates");
        bool facialAnimations = animator.GetBool("FacialAnimationsActive");
    if (currentbaseState == 4)
        {
            LookAtPlayerStateActive = true;
            RandomAnimationStateActive = false;
            RandomFacialAnimationState = false;

            if ( facialAnimations == true)
            {
                LookAtPlayerStateActive = false;
                RandomAnimationStateActive = false;
                RandomFacialAnimationState = true;
            }
        }
        else if (currentbaseState == 5) 
            {
            LookAtPlayerStateActive = false;
            RandomAnimationStateActive = true;
            RandomFacialAnimationState = false;
        }
        else
        {
            LookAtPlayerStateActive = false;
            RandomAnimationStateActive = false;
            RandomFacialAnimationState = false;
            timer = 0.0f;
            timerFace = 0.0f;
        }

        // Wenn die TimeUntilAnimationStart vorbei ist wird in den RandomAnimationState gewechselt und eine der Zufälligen Animationen Abgespielt 
        if (LookAtPlayerStateActive == true && timer >= TimeUntilAnimationStart)
    {
        float aimAtPlayerAnimations = Random.Range(1, 5); // 1 bis 4 (einschließlich)
        animator.SetFloat("AimAtPlayerAnimations", aimAtPlayerAnimations);
        animator.SetInteger("BaseStates", 5);
        
    }

        // Wenn die TimeUntilAnimationFacialStart vorbei ist wird im Layer FacialAnimationsLayer eine zufällige Facial animation über der Aktuellen Pose Abgespielt  
        if (LookAtPlayerStateActive == true && timerFace >= TimeUntilFacialStart)
        {
            float RandomFacialAnimation = Random.Range(1, 5); // 1 bis 4 (einschließlich)
            animator.SetFloat("AimAtPlayerFacialAnimations", RandomFacialAnimation);
            animator.SetBool("FacialAnimationsActive", true);
        }

        if (RandomFacialAnimationState == true && IsAnimationFinished("AimRandomFacialAnimation", "FacialAnimationLayer"))
        {
            // Nachdem die RandomFacialAnimation beendet ist wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimation start generiert
            Debug.Log("FacialAnimation ist Beendet");
            TimeUntilFacialStart = Random.Range(MinTimeUntilFacialStart, MaxTimeUntilFacialStart);

            timerFace = 0.0f;
            animator.SetBool("FacialAnimationsActive", false);
             // Reset Timer
        }


        if (RandomAnimationStateActive == true && IsAnimationFinished("AimRandomAnimation", "Base Layer"))
    {
         // Nachdem die Random Animation beendet ist wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimation start generiert

        animator.SetInteger("BaseStates", 4);
        timer = 0.0f; // Reset Timer
        TimeUntilAnimationStart = Random.Range(MinTimeUntilAnimationStart, MaxTimeUntilAnimationStart);
    }
}

   

    bool IsAnimationFinished(string animation, string layername)
{

        int layerIndex = animator.GetLayerIndex(layername);
    // Überprüft, ob die aktuelle Animation in RandomAnimation beendet ist
    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
    return stateInfo.IsName(animation) && stateInfo.normalizedTime >= 1.0f;
}
}