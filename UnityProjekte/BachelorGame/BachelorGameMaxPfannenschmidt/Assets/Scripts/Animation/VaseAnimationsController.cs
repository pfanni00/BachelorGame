using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseAnimationsController : MonoBehaviour
{

    public Animator VaseFallAnimation;
    public Animator VaseSplitterAnimation;
    public Animator SchlüsselAnimator;
    public bool StartAnimation;
    // Start is called before the first frame update
    void Start()
    {
        StartAnimation = false;
        VaseSplitterAnimation.gameObject.SetActive(false);
        SchlüsselAnimator.gameObject.SetActive(false); 

    }



    // Update is called once per frame
    void Update()
    {
        if (StartAnimation == true && VaseFallAnimation != null)
        {
            VaseFallAnimation.SetBool("Start", true);
            StartCoroutine(WaitForAnimationEnd("Vase_fall"));
        }
    }

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

    private void OnAnimationEnd()
    {
        VaseSplitterAnimation.gameObject.SetActive(true);
        VaseSplitterAnimation.SetBool("Start", true);
        SchlüsselAnimator.gameObject.SetActive(true);
        SchlüsselAnimator.SetBool("Start", true);
        VaseFallAnimation.gameObject.SetActive(false);
        Debug.Log("Animation beendet, Funktion ausgeführt.");

    }
}
