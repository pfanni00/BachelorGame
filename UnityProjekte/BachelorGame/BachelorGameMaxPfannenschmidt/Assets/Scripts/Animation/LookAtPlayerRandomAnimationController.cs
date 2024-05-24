
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
        bool randomAnimations = animator.GetBool("RandomAnimationisActive");
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

            if ( randomAnimations == true) 
            {
                LookAtPlayerStateActive = false;
                RandomAnimationStateActive = true;
                RandomFacialAnimationState = false;
            }
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
            animator.SetBool("RandomAnimationisActive", true);
        }

        if (RandomAnimationStateActive == true && IsAnimationFinished("AimRandomAnimation"))
        {
            // Nachdem die Random Animation beendet ist wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimation start generiert
            animator.SetBool("RandomAnimationisActive", false);
            timer = 0.0f; // Reset Timer
            TimeUntilAnimationStart = Random.Range(MinTimeUntilAnimationStart, MaxTimeUntilAnimationStart);
        }

        // Wenn die TimeUntilAnimationFacialStart vorbei ist wird im Layer FacialAnimationsLayer eine zufällige Facial animation über der Aktuellen Pose Abgespielt  
        if (LookAtPlayerStateActive == true && timerFace >= TimeUntilFacialStart)
        {
            float RandomFacialAnimation = Random.Range(1, 5); // 1 bis 4 (einschließlich)
            animator.SetFloat("AimAtPlayerFacialAnimations", RandomFacialAnimation);
            animator.SetBool("FacialAnimationsActive", true);
        }

        if (RandomFacialAnimationState == true && IsAnimationFinished("AimRandomFacialAnimation"))
        {
            // Nachdem die RandomFacialAnimation beendet ist wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimation start generiert
            Debug.Log("FacialAnimation ist Beendet");
            TimeUntilFacialStart = Random.Range(MinTimeUntilFacialStart, MaxTimeUntilFacialStart);

            timerFace = 0.0f;
            animator.SetBool("FacialAnimationsActive", false);
             // Reset Timer
        }


       
}

   

    bool IsAnimationFinished(string animation)
{

       
    // Überprüft, ob die aktuelle Animation in RandomAnimation beendet ist
    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(1);
    return stateInfo.IsName(animation) && stateInfo.normalizedTime >= 1.0f;
}
}