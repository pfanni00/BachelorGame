using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseAnimationsController : MonoBehaviour
{
    // dieses Script spielt die Animationen der Zerbrechenden Vase in richtiger Reihenfolge ab. Wenn StartAnimation = true ist wird zuerst die VaseFallAnimation Abgespielt und danach VaseSplitter- und Schl�sselAnimation
    public Animator VaseFallAnimation;
    public Animator VaseSplitterAnimation;
    public Animator SchlüsselAnimator;
    public Animator KatzeAnimator;
    public bool StartAnimation;
       public AudioSource Source;
    public AudioClip clip;
    private bool audioPlayed;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayed = false;
        StartAnimation = false;
        VaseSplitterAnimation.gameObject.SetActive(false);
        SchlüsselAnimator.gameObject.SetActive(false); 

    }



    // Update is called once per frame
    void Update()
    {

        // wenn die Katzen Animation in welcher die Vase umgeworfen wird l�uft, wird die entsprechend darauffolgende Vasen animation gestarted 
        bool AnimationTrigger = KatzeAnimator.GetBool("VaseAnimationTrigger");
        //Debug.Log(AnimationTrigger);
        if (AnimationTrigger == true)
        {
            StartCoroutine(StartAnimationAfterSeconds());
        }

        
        if (StartAnimation == true && VaseFallAnimation != null)
        {

        if (!audioPlayed)
        {
            Source.clip = clip;
            Source.Play();
            audioPlayed = true;
        }
            VaseFallAnimation.SetBool("Start", true);
            StartCoroutine(WaitForAnimationEnd("Vase_fall"));
        }
       
    }
    // Hier wird gepr�ft ob die Erste VasenAnimation zuende Abgespielt wurde
    private IEnumerator WaitForAnimationEnd(string animation)
    {
        if (VaseFallAnimation != null)
        {
            // Warte, bis die Animation gestartet ist
            while (!VaseFallAnimation.GetCurrentAnimatorStateInfo(0).IsName(animation))
            {
                yield return null;
            }

            // Warte, bis die Animation beendet ist
            while (VaseFallAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                yield return null;
            }

            // Rufe die Methode auf, nachdem die Animation beendet ist
            OnAnimationEnd();
            yield break;
        }
    }

    private IEnumerator StartAnimationAfterSeconds()
    {
       // animation wird nach Sekundenzahl gestarted 
        yield return new WaitForSeconds(0.5f);
        StartAnimation = true;
         
        
    }


    private void OnAnimationEnd()
    // Wenn die erste Animation der Herunterfallenden Vase Endet wird die Animation des Schl�ssels und der Zersplitternden Vase Abgespielt. 
    {
        VaseSplitterAnimation.gameObject.SetActive(true);
        VaseSplitterAnimation.SetBool("Start", true);
        SchlüsselAnimator.gameObject.SetActive(true);
        SchlüsselAnimator.SetBool("Start", true);
        VaseFallAnimation.gameObject.SetActive(false);
        Debug.Log("Animation beendet, Funktion ausgef�hrt.");

    }
}
