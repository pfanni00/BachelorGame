using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndingImageAnimation : MonoBehaviour
{
    public float transitionTime;
    public float FadeInStartTime;
    public float FadeOutStartTime;

    private float timer;
    
    private float timerFadeIn;

    private bool FadeInIsAcitve;
    private bool FadeOutIsAcitve;

    private bool FadeComplete;
    private bool FadeoutComplete;

    private bool isVisible;
    
    public Image endingImage;
    
    private Color Black = Color.black;
    private Color White = Color.white;

    public float zoomSpeed = 0.1f;
    public float maxZoom = 2.0f;

    private RectTransform rectTransform;
    private bool isZoomingIn = false;

    // Start is called before the first frame update
    void Start()
    {
        endingImage.color = Black;
        FadeInIsAcitve = false;
        FadeOutIsAcitve = false;
       // transitionTime = transitionTimeFixed;
        FadeComplete = false;
        FadeoutComplete = false;

        if (endingImage != null)
        {
            rectTransform = endingImage.GetComponent<RectTransform>();
        }
    }

    

    // Update is called once per frame
    void Update()
    {


        timerFadeIn += Time.deltaTime;
        timer += Time.deltaTime;

// wenn isZoomingIn = true wird der Zoom Gestarted 
        if (isZoomingIn && rectTransform.localScale.x < maxZoom)
            {
            rectTransform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed) * Time.deltaTime;
            }


// wenn Timer Fade in die FadeInStartTime Überschreitet wird der Zoom gestarted und das bild eingeblendet
        if(FadeComplete == false)
        {
            //timerFadeIn += Time.deltaTime;

            if (timerFadeIn >= FadeInStartTime)
            {
            fadeIn();
            StartZoom();
            FadeComplete = true;
            }
        } 

// wennn der FadeIn Abgeschlossen ist und timerFadeIn die FadeOutStartTime erreicht wird das bild wieder ausgeblendet
        if(FadeoutComplete == false)
        {
            if(timerFadeIn >= FadeOutStartTime)
            {
            fadeOut();
            FadeoutComplete = true;
            }
        }




// wenn isVisible = true ist wird das bild eingefaded 
        if (FadeInIsAcitve == true && isVisible == true)
        {
            endingImage.color = Color.Lerp(Black, White, timer / transitionTime);

            if (timer >= transitionTime)
            {
                FadeInIsAcitve = false;
            }
        }
// wenn isVisible = false ist wird es wiederum ausgeblendet 
         if (FadeOutIsAcitve == true && isVisible == false)
        {
            endingImage.color = Color.Lerp(White, Black, timer / transitionTime);

            if (timer >= transitionTime)
            {
                FadeOutIsAcitve = false;
            }
        }
    }
    
    public void fadeIn()
    {
        timer = 0.0f;
        isVisible = true;
        FadeInIsAcitve = true;
    }

    public void fadeOut()
    {
        timer = 0.0f;
        isVisible = false;
        FadeOutIsAcitve = true;
    }

    public void StartZoom()
    {
        isZoomingIn = true;
    }

    public void StopZoom()
    {
        isZoomingIn = false;
    }

    }
