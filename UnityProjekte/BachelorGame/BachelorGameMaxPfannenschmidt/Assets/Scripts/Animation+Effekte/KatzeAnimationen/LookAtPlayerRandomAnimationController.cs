using UnityEngine;

public class LookAtPlayerRandomAnimation : MonoBehaviour
{
    // Referenz zum Animator
    public Animator animator;

    // Zeit bis zur nächsten zufälligen Animation, berechnet aus MinTimeUntilAnimationStart und MaxTimeUntilAnimationStart
    private float TimeUntilAnimationStart;
    public float MinTimeUntilAnimationStart;
    public float MaxTimeUntilAnimationStart;

    // Zeit bis zur nächsten zufälligen Facial Animation, berechnet aus MinTimeUntilFacialStart und MaxTimeUntilFacialStart
    private float TimeUntilFacialStart;
    public float MinTimeUntilFacialStart;
    public float MaxTimeUntilFacialStart;

    // Timer zum Abspielen der zufälligen Animation
    private float timer;
    private float timerFace;

    // Zustandsvariablen
    private bool LookAtPlayerStateActive;
    private bool RandomAnimationStateActive;
    private bool RandomFacialAnimationState;

    // Speichert den aktuellen Base State
    private int currentbaseState;

    // Gibt an, ob eine KeySequence läuft
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
        // Überprüft, ob die KeySequence läuft
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

        // Setzt die Zustände basierend auf dem aktuellen BaseState
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

        // Wenn die KeySequence abgespielt wird, werden die Random Animationen abgeschaltet, um überlappende Animationen zu verhindern
        if (keySequenceIsRunning == false)
        {
            // Wenn die TimeUntilAnimationStart vorbei ist, wird in den RandomAnimationState gewechselt und eine der zufälligen Animationen abgespielt
            if (LookAtPlayerStateActive == true && timer >= TimeUntilAnimationStart)
            {
                float aimAtPlayerAnimations = Random.Range(1, 5); // 1 bis 4 (einschließlich)
                animator.SetFloat("AimAtPlayerAnimations", aimAtPlayerAnimations);
                animator.SetBool("RandomAnimationisActive", true);
                animator.SetBool("AnimationisPlaying", true);

                timer = 0.0f; // Timer zurücksetzen
            }
        }

        // Überprüfen, ob die zufällige Animation beendet ist, und entsprechend den Zustand zurücksetzen und neue Zeit berechnen
        if (RandomAnimationStateActive == true && IsAnimationFinished("AimRandomAnimation"))
        {
            // Nachdem die Random Animation beendet ist, wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilAnimationStart generiert
            TimeUntilAnimationStart = Random.Range(MinTimeUntilAnimationStart, MaxTimeUntilAnimationStart);
            animator.SetBool("RandomAnimationisActive", false);
            animator.SetBool("AnimationisPlaying", false);
        }

        // Wenn die KeySequence nicht läuft, prüfe auf Facial Animationen und starte diese gegebenenfalls
        if (keySequenceIsRunning == false)
        {
            // Wenn die TimeUntilFacialStart vorbei ist, wird im Layer FacialAnimationsLayer eine zufällige Facial Animation über der aktuellen Pose abgespielt
            if (LookAtPlayerStateActive == true && timerFace >= TimeUntilFacialStart)
            {
                float RandomFacialAnimation = Random.Range(1, 5); // 1 bis 4 (einschließlich)
                animator.SetFloat("AimAtPlayerFacialAnimations", RandomFacialAnimation);
                animator.SetBool("FacialAnimationsActive", true);
                animator.SetBool("AnimationisPlaying", true);

                timerFace = 0.0f; // Timer zurücksetzen
            }
        }

        // Überprüfen, ob die zufällige Facial Animation beendet ist, und entsprechend den Zustand zurücksetzen und neue Zeit berechnen
        if (RandomFacialAnimationState == true && IsAnimationFinished("AimRandomFacialAnimation"))
        {
            // Nachdem die RandomFacialAnimation beendet ist, wird zurück in den LookAtPlayerState gewechselt und eine neue TimeUntilFacialStart generiert
            TimeUntilFacialStart = Random.Range(MinTimeUntilFacialStart, MaxTimeUntilFacialStart);
            animator.SetBool("FacialAnimationsActive", false);
            animator.SetBool("AnimationisPlaying", false);
        }
    }

    // Überprüft, ob die aktuelle Animation in RandomAnimation beendet ist
    bool IsAnimationFinished(string animation)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(1);
        return stateInfo.IsName(animation) && stateInfo.normalizedTime >= 1.0f;
    }
}