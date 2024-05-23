using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    public static EndingAnimation Instance;
    public Animator FensterLAnimator;
    public Animator FensterRAnimator;
    public Animator Wohnungst�rAnimator;

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
        Wohnungst�rAnimator.SetBool("Start", true);

        StartCoroutine(WaitForAnimationEnd());
    }

    private IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSeconds(15);


        // Variable AnimationIsFinished wir auf true gesetzt nachdem die animation abgeschlossen ist
        AnimationIsFinished = true;

    }
   }
