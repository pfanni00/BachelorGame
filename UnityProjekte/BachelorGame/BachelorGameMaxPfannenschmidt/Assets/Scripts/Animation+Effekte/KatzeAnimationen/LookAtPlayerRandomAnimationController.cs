using UnityEngine;

public class LookAtPlayerRandomAnimation : MonoBehaviour
{
    // Referenz zum Animator
    public Animator animator;

    // Zeit bis zur n�chsten zuf�lligen Animation, berechnet aus MinTimeUntilAnimationStart und MaxTimeUntilAnimationStart
    private float TimeUntilAnimationStart;
    public float MinTimeUntilAnimationStart;
    public float MaxTimeUntilAnimationStart;

    // Zeit bis zur n�chsten zuf�lligen Facial Animation, berechnet aus MinTimeUntilFacialStart und MaxTimeUntilFacialStart
    private float TimeUntilFacialStart;
    public float MinTimeUntilFacialStart;
    public float MaxTimeUntilFacialStart;

    // Timer zum Abspielen der zuf�lligen Animation
    private float timer;
    private float timerFace;

    // Zustandsvariablen
    private bool LookAtPlayerStateActive;
    private bool RandomAnimationStateActive;
    private bool RandomFacialAnimationState;

    // Speichert den aktuellen Base State
    private int currentbaseState;

    // Gibt an, ob eine KeySequence l�uft
    private bool keySequenceIsRunning;

    void Start()
    {
        timer = 0.0f;
        timerFace = 0.0f;
        TimeUntilAnimationStart = 14f;
        TimeUntilFacialStart = 10f;
    }

    void Update()
    {
        // �berpr�ft, ob die KeySequence l�uft
        keySequenceIsRunning = animator.GetBool("GetKeySequenceIsRunning");

        // Timer laufen nur im LookAtPlayer State und wenn die KeySequence nicht aktiv ist
        if (LookAtPlayerStateActive == true && keySequenceIsRunning == false)
        {
            timer += Time.deltaTime;
            timerFace += Time.deltaTime;
        }

        // Holen der aktuellen BaseState, FacialAnimations und RandomAnimations Werte aus dem Animator
        int currentbaseState = animator.GetInteger("BaseStates");
        bool facialAnimations = animator.GetBool("FacialAnimationsActive");
        bool randomAnimations = animator.GetBool("RandomAnimationisActive");

        // Setzt die Zust�nde basierend auf dem aktuellen BaseState
        if (currentbaseState == 4)
        {
            LookAtPlayerStateActive = true;
            RandomAnimationStateActive = false;
            RandomFacialAnimationState = false;

            if (facialAnimations == true)
            {
                LookAtPlayerStateActive = false;
                RandomAnimationStateActive = false;
                RandomFacialAnimationState = true;
            }

            if (randomAnimations == true)
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

        // Wenn die KeySequence abgespielt wird, werden die Random Animationen abgeschaltet, um �berlappende Animationen zu verhindern
        if (keySequenceIsRunning == false)
        {
            // Wenn die TimeUntilAnimationStart vorbei ist, wird in den RandomAnimationState gewechselt und eine der zuf�lligen Animationen abgespielt
            if (LookAtPlayerStateActive == true && timer >= TimeUntilAnimationStart)
            {
                float aimAtPlayerAnimations = Random.Range(1, 5); // 1 bis 4 (einschlie�lich)
                animator.SetFloat("AimAtPlayerAnimations", aimAtPlayerAnimations);
                animator.SetBool("RandomAnimationisActive", true);
                animator.SetBool("AnimationisPlaying", true);

                timer = 0.0f; // Timer zur�cksetzen
            }
        }

        // �berpr�fen, ob die zuf�llige Animation beendet ist, und entsprechend den Zustand zur�cksetzen und neue Zeit berechnen
        if (RandomAnimationStateActive == true && IsAnimationFinished("AimRandomAnimation"))
        {
            // Nachdem die Random Animation beendet ist, wird zur�ck in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimationStart generiert
            TimeUntilAnimationStart = Random.Range(MinTimeUntilAnimationStart, MaxTimeUntilAnimationStart);
            animator.SetBool("RandomAnimationisActive", false);
            animator.SetBool("AnimationisPlaying", false);
        }

        // Wenn die KeySequence nicht l�uft, pr�fe auf Facial Animationen und starte diese gegebenenfalls
        if (keySequenceIsRunning == false)
        {
            // Wenn die TimeUntilFacialStart vorbei ist, wird im Layer FacialAnimationsLayer eine zuf�llige Facial Animation �ber der aktuellen Pose abgespielt
            if (LookAtPlayerStateActive == true && timerFace >= TimeUntilFacialStart)
            {
                float RandomFacialAnimation = Random.Range(1, 5); // 1 bis 4 (einschlie�lich)
                animator.SetFloat("AimAtPlayerFacialAnimations", RandomFacialAnimation);
                animator.SetBool("FacialAnimationsActive", true);
                animator.SetBool("AnimationisPlaying", true);

                timerFace = 0.0f; // Timer zur�cksetzen
            }
        }

        // �berpr�fen, ob die zuf�llige Facial Animation beendet ist, und entsprechend den Zustand zur�cksetzen und neue Zeit berechnen
        if (RandomFacialAnimationState == true && IsAnimationFinished("AimRandomFacialAnimation"))
        {
            // Nachdem die RandomFacialAnimation beendet ist, wird zur�ck in den LookAtPlayerState gewechselt und eine neue TimeUntilFacialStart generiert
            TimeUntilFacialStart = Random.Range(MinTimeUntilFacialStart, MaxTimeUntilFacialStart);
            animator.SetBool("FacialAnimationsActive", false);
            animator.SetBool("AnimationisPlaying", false);
        }
    }

    // �berpr�ft, ob die aktuelle Animation in RandomAnimation beendet ist
    bool IsAnimationFinished(string animation)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(1);
        return stateInfo.IsName(animation) && stateInfo.normalizedTime >= 1.0f;
    }
}