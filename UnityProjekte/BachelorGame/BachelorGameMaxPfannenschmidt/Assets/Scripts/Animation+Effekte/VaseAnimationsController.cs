using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseAnimationsController : MonoBehaviour
{
    // dieses Script spielt die Animationen der Zerbrechenden Vase in richtiger Reihenfolge ab. Wenn StartAnimation = true ist wird zuerst die VaseFallAnimation Abgespielt und danach VaseSplitter- und SchlüsselAnimation
    
    // referenz zum VaseFallAnimator enthält Clip in dem die Vase runterfällt
    public Animator VaseFallAnimation;
    // referenz zum VaseSplitterAnimator enthält Clip in dem die Vase zerspringt 
    public Animator VaseSplitterAnimation;
    // referenz zum SchlüsselAnimator enthält Clip von Schlüssel der Aus Vase Springt.
    public Animator SchlüsselAnimator;

    // referenz zum CatAnimator enthält alle animationen der Katze 
    public Animator KatzeAnimator;
    
    // fragt ab ob Animation bereits gestarted ist. 
    public bool StartAnimation;

    // Audio Source für Vase Audio 
    public AudioSource Source;
    // Clip der wärend der Animation abgespielt wird 
    public AudioClip clip;

    // fragt ab ob Audio bereits abgespielt wurde.
    private bool audioPlayed;


    // Start is called before the first frame update
    void Start()
    {
        // zum Start Animation/Audio noch nicht abgespielt 
        audioPlayed = false;
        StartAnimation = false;

        //VaseSplitter und Schlüssel GameObject sind Inactiv (VaseFallAnimatin läuft über eigenes GameObject)
        VaseSplitterAnimation.gameObject.SetActive(false);
        SchlüsselAnimator.gameObject.SetActive(false); 
    }



    // Update is called once per frame
    void Update()
    {

        // läuft im KatzeAnimator die Paw_R 0 animation wird der VaseAnimationsTrigger = true gesetzt und daher automatisch die darauffolgende Vase animation abgespielt
        bool AnimationTrigger = KatzeAnimator.GetBool("VaseAnimationTrigger");
        
        if (AnimationTrigger == true)
        {
            // VaseAnimation wird mit verzögerung gestarted 
            StartCoroutine(StartAnimationAfterSeconds());
        }

        // Wenn StartAnimation = true wird Animatin gestarted und audio Abgespielt
        if (StartAnimation == true && VaseFallAnimation != null)
        {
            // audio wird nur gestarted wenn es nicht bereits gestarted wurde 
            if (!audioPlayed)
            {
                // Audio Clip wird Source zugeteilt
                Source.clip = clip;
                // Audio wird abgespielt
                Source.Play();
                // variable wird = true gesetzt um sicherzustellen da Audio nur einmal abgespielt wird. 
                audioPlayed = true;
            }
            // VaseFallAnimation wird gestarted 
                VaseFallAnimation.SetBool("Start", true);
            // Coroutine für das abspielen von weiteren Animationen wird gestarted. 
                StartCoroutine(WaitForAnimationEnd("Vase_fall"));
            }
       
    }


    // Coroutine um Vase Animations kette zu starten. 
    private IEnumerator StartAnimationAfterSeconds()
    {
        // animation wird nach Sekundenzahl gestarted damit sie synchron zur katzen Animation läuft. 
        yield return new WaitForSeconds(0.5f);
        StartAnimation = true;
    }



    // Coroutine Prüft ob animation zuende ist und Spielt nächste Animation bei Ende ab
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

            // Rufe die Methode zum Abspielen der nächsten Animation auf, nachdem die Animation beendet ist
            OnAnimationEnd();
            yield break;
        }
    }


    // diese Coroutine Spielt die VaseSplitter und Schlüssel Animation ab
    private void OnAnimationEnd()
    
    {   // GameObject der VaseSplitter Animation wird sichtbar.
        VaseSplitterAnimation.gameObject.SetActive(true);
        //vaseSplitter Animation wird gestartet 
        VaseSplitterAnimation.SetBool("Start", true);
        // Schlüssel GameObject wird sichtbar 
        SchlüsselAnimator.gameObject.SetActive(true);
        // Schlüssel animation wird gestartet 
        SchlüsselAnimator.SetBool("Start", true);

        //VaseFall GameObject wird unsichtbar 
        VaseFallAnimation.gameObject.SetActive(false);
    }
}
