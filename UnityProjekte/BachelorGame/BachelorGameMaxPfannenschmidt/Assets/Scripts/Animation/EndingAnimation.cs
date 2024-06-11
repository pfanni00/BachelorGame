using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    public static EndingAnimation Instance;
    public Animator FensterLAnimator;
    public Animator FensterRAnimator;
    public Animator WohnungstürAnimator;
    public AudioSource Fenstersource;
    public AudioSource TürSource;
    public AudioSource Herzschlag;

    public bool AnimationIsFinished;

    void Awake()
    {
        Instance = this;
    }

    void Start () 
    {
        AnimationIsFinished = false;
    }

    public void StartEndingAnimation()
    {
        Fenstersource.Play();
        TürSource.Play();
        FensterLAnimator.SetBool("Start", true);
        FensterRAnimator.SetBool("Start", true);
        WohnungstürAnimator.SetBool("Start", true);
       // lightChange lc = gameObject.GetComponent<lightChange>();
        //lc.switchlight();
        StartCoroutine(WaitForLightsout());
                StartCoroutine(WaitForLightson());

        StartCoroutine(WaitForheartmonitorSound());

        StartCoroutine(WaitForAnimationEnd());
    }

    private IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSeconds(15);

        // Variable AnimationIsFinished wir auf true gesetzt nachdem die animation abgeschlossen ist außerdem wird das licht auf die end lichter geändert 
        AnimationIsFinished = true;
 
    }

     private IEnumerator WaitForLightsout()
    {
        yield return new WaitForSeconds(2);

        // nachdem der timer zuende ist gehen die lichter aus 
    
        LightTransition lt = gameObject.GetComponent<LightTransition>();
        lt.WohzimmerLightOFF();
    }

    private IEnumerator WaitForLightson()
    {
        yield return new WaitForSeconds(14);

        // nachdem der timer zuende ist gehen die lichter aus 
        
        LightTransition lt = gameObject.GetComponent<LightTransition>();
        lt.KrankenzimmerlightOn();
    }

    private IEnumerator WaitForheartmonitorSound()
    {
        yield return new WaitForSeconds(8);
        Herzschlag.Play();
    }
   }
