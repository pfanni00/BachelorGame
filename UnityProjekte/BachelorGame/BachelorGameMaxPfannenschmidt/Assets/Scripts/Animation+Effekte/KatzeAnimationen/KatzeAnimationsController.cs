using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeAnimationsController : MonoBehaviour
{
    // dieses Script steuert die Animationen der Katze 

    public static KatzeAnimationsController Instance;

    // referenz zum animator 
    Animator animator;

    // variable gibt an ob Katze den Spieler ansieht 
    private bool IsLookingAtPlayer;

    // variable gibt an ob dialog gestartet wurde 
    private bool DialogWasStarted;

    // aktueller animations State 
    public int currentState;

    // referenz zum DialogTrigger 
    public GameObject dialogTriggerObj;

    // variable gibt an ob zufalls animation abgespielt wird
    private bool RandomAnimationIsPlaying;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // verbindung zum Animator wird hergestellt 
        animator = GetComponent<Animator>();

        // dialog wurde nicht gestarted 
        DialogWasStarted = false;
        
        // Animator wird auf BaseState(1) gesetzt (Sitzen)
        SetState(1);
    }

    // Update is called once per frame
    void Update()
    {
        //lokale variable RandomAnimationIsPlaying wird mit Animator variable abgeglichen 
        RandomAnimationIsPlaying = animator.GetBool("AnimationisPlaying");

        //lokale variable DialogWasStarted wird mit KatzeInteractor abgeglichen 
        KatzeInteraction ki = gameObject.GetComponent<KatzeInteraction>();
        DialogWasStarted = ki.HasBeenInteracted;

        // wenn das Dialogsystem geöffnet/geschlossen wird, wird die Animation der Katze angepasst 
        if (HUDControlls.Instance.DialogsystemisOpen != IsLookingAtPlayer)
        {
            // IsLookingAtPlayer wird mit öffnung des Dialogssystems gleichgesetzt 
            IsLookingAtPlayer = HUDControlls.Instance.DialogsystemisOpen;
            
            if(IsLookingAtPlayer == true)
            {// wenn Dialogsystem offen ist wird BaseState(4) gestarted (Katze sieht spieler an)
                SetState(4);
            }else if (IsLookingAtPlayer == false) 
            {// wenn Dialogsystem geschlossen wird der Idle State gestarted 
                IdleAnimationState();
            }
        }
    }
    
    


    private IEnumerator SitDownAfterSeconds(float seconds)
    {
        // animation wird nach eingegebenen seconds gestarted 
        yield return new WaitForSeconds(seconds);
        if (currentState == 0)
        {
            // Animator wird auf BaseState(1) gesetzt (Sitzen)
            SetState(1);
        }
    }

    // Funktion um den State des animators zu setzen 
    public void SetState(int state)
    {
        // state wird nur gesetzt wenn er sich verändert. wärend die futter animation läuft kann der state nicht geändert werden. 
    if (state != currentState && currentState != 2)
        {
            //Coroutine um State erst nach abschluss bisheriger animationen zu setzen wird gestarted 
           StartCoroutine(WaitForRandomAnimationEnd(state));
            
            // currentState wird aktualisiert. 
            currentState = state;
            
        }  
    }


    IEnumerator WaitForRandomAnimationEnd(int Thisstate)
    {
        // wärend eine zufallsanimation abgespielt wird passiert nichts 
        while (RandomAnimationIsPlaying == true)
        {
            
            yield return null;

        }
        // wird keine animation mehr abgespielt wird der eingegebene State im Animator gesetzt 
        animator.SetInteger("BaseStates", Thisstate);
    }


    //Animations verhalten der Katze bevor der Dialog gestarted wurde 
    public void StartAnimationState(bool lookAtPlayer)
    {
        if (DialogWasStarted == false)
        {// wird lookAtPlayer als true angegeben wird der Animator BaseState(4) gesetzt (Katze sieht spieler an)

            if (lookAtPlayer == true)
            {
                SetState(4);
            }

            else if (lookAtPlayer == false)
            {// wird lookAtPlayer als false angegeben wird der Animator BaseState(0) gesetzt (Katze ist idle)

                SetState(0);
            }
        }
    }

    public void IdleAnimationState()
    {// wird lookAtPlayer als false angegeben wird der Animator BaseState(0) gesetzt (Katze ist idle)
        SetState(0);
        // Coroutine wird gestarted. Katze setzt sich nach 8 secunden hin
        StartCoroutine(SitDownAfterSeconds(8));
    }
  


    public void StartKeyAnimation()
    {// Fütter Animation wird gestarted. Im Animator wird nach abschluss automatisch zu state 3 Übergegangen. 
        SetState(2);
    }
}
