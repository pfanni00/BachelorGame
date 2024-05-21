using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatzeAnimationsController : MonoBehaviour
{
    public static KatzeAnimationsController Instance;

    Animator animator;
    private bool IsLookingAtPlayer;
    private bool DialogWasStarted;
    private int currentState;
    // = BaseStates im Animator
    public GameObject dialogTriggerObj;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        DialogWasStarted = false;

    }

    // Update is called once per frame
    void Update()
    {
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
      //  IsLookingAtPlayer = HUDControlls.Instance.DialogsystemisOpen;


        
        /*  if (baseStates != 2) {
              if (DialogWasStarted == false)
              {
                  DialogTrigger dialogTrigger = dialogTriggerObj.GetComponent<DialogTrigger>();

                  if (dialogTrigger.TriggerActive == true)
                  {
                      baseStates = 4;
                  }
                //  else if(dialogTrigger.TriggerActive == false) { baseStates = 0; }
              }

              else if (DialogWasStarted == true)
              {
                  if (HUDControlls.Instance.DialogsystemisOpen == true)
                  {
                      Debug.Log("LookAtPlayer");
                      //StopCoroutine(SitDownAfterSeconds(7, 10));

                      baseStates = 4;
                  }
                  else if (HUDControlls.Instance.DialogsystemisOpen == false)
                  {
                      baseStates = 1;

                      StartCoroutine(SitDownAfterSeconds(5f));
                  }
              }*/
    
        



      /*  //das script dialogTrigger wird untersucht
        DialogTrigger dialogTrigger = dialogTriggerObj.GetComponent<DialogTrigger>();
        Debug.Log(dialogTrigger.TriggerActive);
        //wenn der Spieler in den Dialog Trigger Collider tritt sieht die Katze zu ihm
        if (dialogTrigger.TriggerActive == true)
        {
            baseStates = 4;
        }*/
       

       // animator.SetInteger("BaseStates", baseStates);
    


    private IEnumerator SitDownAfterSeconds(float seconds)
    {
       // baseStates = 0;

        // animation wird nach Sekundenzahl gestarted 
        // float seconds = Random.Range(minseconds, maxseconds);
        yield return new WaitForSeconds(seconds);
        SetState(1);

    }

    public void SetState(int state)
    {
    if (state != currentState && currentState != 2)
        {
        animator.SetInteger("BaseStates", state);
        currentState = state;
        }  
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
