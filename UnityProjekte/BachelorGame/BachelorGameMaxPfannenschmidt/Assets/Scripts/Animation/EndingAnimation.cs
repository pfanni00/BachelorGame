using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    public static EndingAnimation Instance;
    public Animator FensterLAnimator;
    public Animator FensterRAnimator;
    public Animator WohnungstürAnimator;

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
        FensterLAnimator.SetBool("Start", true);
        FensterRAnimator.SetBool("Start", true);
        WohnungstürAnimator.SetBool("Start", true);
       // lightChange lc = gameObject.GetComponent<lightChange>();
        //lc.switchlight();
        StartCoroutine(WaitForLightsout());

        StartCoroutine(WaitForAnimationEnd());
    }

    private IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSeconds(15);

        // Variable AnimationIsFinished wir auf true gesetzt nachdem die animation abgeschlossen ist außerdem wird das licht auf die end lichter geändert 
        AnimationIsFinished = true;
        lightChange lc = gameObject.GetComponent<lightChange>();
        lc.switchlight();
    }

     private IEnumerator WaitForLightsout()
    {
        yield return new WaitForSeconds(4);

        // nachdem der timer zuende ist gehen die lichter aus 
        
        lightChange lc = gameObject.GetComponent<lightChange>();
        lc.switchlight();
    }
   }
