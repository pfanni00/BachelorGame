using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CreditBlend : MonoBehaviour
{
    public float transitionTime;
    public float FadeInStartTime;
    public float FadeOutStartTime;
    public bool StartCredits;
    
    private float timerFadeIn;

    private bool FadeInIsAcitve;
    private bool FadeOutIsAcitve;

    private bool FadeComplete;
    private bool FadeoutComplete;

    
    public TMP_Text Credit;
    

    // Start is called before the first frame update
    void Start()
    {
        FadeInIsAcitve = false;
        FadeOutIsAcitve = false;
       // transitionTime = transitionTimeFixed;
        FadeComplete = false;
        FadeoutComplete = false;
    Credit.canvasRenderer.SetAlpha(0.00f);

    }

    // Update is called once per frame
    void Update()
    {

      // wenn die Credits zu ende sind kehr das Spiel ins Hauptmenu zurück
        timerFadeIn += Time.deltaTime;

       


        // credit wird nach ablauf von Timer Fade in eingeblendet
        if(FadeComplete == false)
        {
            //timerFadeIn += Time.deltaTime;

            if (timerFadeIn >= FadeInStartTime)
            {
            fadeIn();
            FadeComplete = true;
            }
        } 

        // credit wird nach ablauf von Timer fadeout in ausgeblendet

        if(FadeoutComplete == false)
        {
            if(timerFadeIn >= FadeOutStartTime)
            {
            fadeOut();
            FadeoutComplete = true;
            }
        }
    }

    
    public void fadeIn()
    {
            Credit.CrossFadeAlpha(1, transitionTime, false);
       // isVisible = true;
        //FadeInIsAcitve = true;
    }

    public void fadeOut()
    {
            Credit.CrossFadeAlpha(0, transitionTime, false);
       // isVisible = false;
        //FadeOutIsAcitve = true;
    }


    

    }

