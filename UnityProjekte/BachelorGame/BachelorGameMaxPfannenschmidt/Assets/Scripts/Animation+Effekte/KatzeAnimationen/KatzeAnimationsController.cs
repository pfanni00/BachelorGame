using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeAnimationsController : MonoBehaviour
{
    public static KatzeAnimationsController Instance;

    Animator animator;
    private bool IsLookingAtPlayer;
    private bool DialogWasStarted;
    public int currentState;
    public GameObject dialogTriggerObj;

    private bool RandomAnimationIsPlaying;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        DialogWasStarted = false;
        SetState(1);

    }

    // Update is called once per frame
    void Update()
    {
        RandomAnimationIsPlaying = animator.GetBool("AnimationisPlaying");

        KatzeInteraction ki = gameObject.GetComponent<KatzeInteraction>();
        DialogWasStarted = ki.HasBeenInteracted;

        if (HUDControlls.Instance.DialogsystemisOpen != IsLookingAtPlayer)
        {
            IsLookingAtPlayer = HUDControlls.Instance.DialogsystemisOpen;
            if(IsLookingAtPlayer == true)
            {
                SetState(4);
            }else if (IsLookingAtPlayer == false) 
            {
                IdleAnimationState();
            }
        }
    }
    
    


    private IEnumerator SitDownAfterSeconds(float seconds)
    {
       // baseStates = 0;

        // animation wird nach Sekundenzahl gestarted 
        // float seconds = Random.Range(minseconds, maxseconds);
        yield return new WaitForSeconds(seconds);
        if (currentState == 0)
        {
            SetState(1);
        }

    }

    public void SetState(int state)
    {
    if (state != currentState && currentState != 2)
        {


           StartCoroutine(WaitForRandomAnimationEnd(state));
            //animator.SetInteger("BaseStates", state);
            currentState = state;
            
        }  
    }


    IEnumerator WaitForRandomAnimationEnd(int Thisstate)
    {
        // Example while loop
        while (RandomAnimationIsPlaying == true)
        {
            // Perform some actions inside the loop

            yield return null;

        }

        animator.SetInteger("BaseStates", Thisstate);
    }


    public void StartAnimationState(bool lookAtPlayer)
    {
        if (DialogWasStarted == false)
        {
            if(lookAtPlayer == true)
            {
                SetState(4);
            }
            else if (lookAtPlayer == false)
            {
                SetState(0);
            }
        }
    }

    public void IdleAnimationState()
    {
        SetState(0);
        StartCoroutine(SitDownAfterSeconds(8));
    }
  


    public void StartKeyAnimation()
    {
        SetState(2);
    }
}
