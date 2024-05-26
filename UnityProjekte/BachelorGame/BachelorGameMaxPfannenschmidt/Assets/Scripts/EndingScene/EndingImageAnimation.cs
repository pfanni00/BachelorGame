using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndingImageAnimation : MonoBehaviour
{
    public float FadeInStartTime;
    public float timer;
    public float timerFadeIn;
    public float transitionTime;
    private bool FadeIsAcitve;
    private bool FadeComplete;
    private bool isVisible;
    public Image endingImage;
    public Color Black = Color.black;
    public Color White = Color.white;

    public float zoomSpeed = 0.1f;
    public float maxZoom = 2.0f;

    private RectTransform rectTransform;
    private bool isZoomingIn = false;

    // Start is called before the first frame update
    void Start()
    {
        endingImage.color = Black;
        FadeIsAcitve = false;

        if (endingImage != null)
        {
            rectTransform = endingImage.GetComponent<RectTransform>();
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        if (isZoomingIn && rectTransform.localScale.x < maxZoom)
            {
            rectTransform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed) * Time.deltaTime;
            }

        if(FadeComplete == false)
        {
            timerFadeIn += Time.deltaTime;

            if (timerFadeIn >= FadeInStartTime)
            {
            fadeIn();
            StartZoom();
            FadeComplete = true;
            }
        } 

        timerFadeIn += Time.deltaTime;
        timer += Time.deltaTime;



        if (FadeIsAcitve == true && isVisible == true)
        {
            endingImage.color = Color.Lerp(Black, White, timer / transitionTime);

            if (timer >= transitionTime)
            {
                transitionTime = 0.0f;
                FadeIsAcitve = false;
            }
        }

         if (FadeIsAcitve == true && isVisible == false)
        {
            endingImage.color = Color.Lerp(White, Black, timer / transitionTime);

            if (timer >= transitionTime)
            {
                transitionTime = 0.0f;
                FadeIsAcitve = false;
            }
        }
    }
    
    public void fadeIn()
    {
        timer = 0.0f;
        timerFadeIn = 0.0f;
        isVisible = true;
        FadeIsAcitve = true;
    }

    public void fadeOut()
    {
        isVisible = false;
        FadeIsAcitve = true;
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
