using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CreditBlend : MonoBehaviour
{// dieses Script controlliert das einblenden der Credits in den EndingScenes

    // dauer des Ein/Ausblenden
    public float transitionTime;
    
    // zeit bis beginn des FadeIn 
    public float FadeInStartTime;

    // zeit bis beginn des FadeOut sollte größer FadeInStartTime sein 
    public float FadeOutStartTime;

    //public bool StartCredits;
    
    // timer für management der FadeTimes 
    private float timerFadeIn;

    // diese variable gibt an ob der FadeIn bereits erfolgt ist
    private bool FadeComplete;

    // diese variable gibt an ob der FadeOut bereits erfolgt ist
    private bool FadeoutComplete;

    // text object welches gefaded wird. 
    public TMP_Text Credit;
    

    // Start is called before the first frame update
    void Start()
    {
        // zu beginn sind FadeIn/Out noch nicht erfolgt        
        FadeComplete = false;
        FadeoutComplete = false;

        // Text object wird über Alpha wert unsichtbar gemacht. 
        Credit.canvasRenderer.SetAlpha(0.00f);
    }

    // Update is called once per frame
    void Update()
    {
        // timer läuft ab beginn continuierlich.
        timerFadeIn += Time.deltaTime;

       


        // credit wird nach ablauf von Timer Fade in eingeblendet
        if(FadeComplete == false)
        {

            if (timerFadeIn >= FadeInStartTime)
            {
                fadeIn();
                // nach start des fadeIn wird FadeComplete auf true gesetzt. dies verhindert erneutes einblenden. 
                FadeComplete = true;
            }
        } 

        // credit wird nach ablauf von Timer fadeout in ausgeblendet
        if(FadeoutComplete == false)
        {
            if(timerFadeIn >= FadeOutStartTime)
            {
            fadeOut();
            // nach beginn des fadeOut wird FadeoutComplete auf true gesetzt. dies verhindert erneutes einblenden. 

            FadeoutComplete = true;
            }
        }
    }

    
    public void fadeIn()
    {
        // text Object Credit wird über Alpha wert sichtbar gemacht. transitionTime bestimmt geschwindigkeit. 
        Credit.CrossFadeAlpha(1, transitionTime, false);
    }

    public void fadeOut()
    {
        // text Object Credit wird über Alpha wert unsichtbar gemacht. transitionTime bestimmt geschwindigkeit. 
        Credit.CrossFadeAlpha(0, transitionTime, false);
    }
}

