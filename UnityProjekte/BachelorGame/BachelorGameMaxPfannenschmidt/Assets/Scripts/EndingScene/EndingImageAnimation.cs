using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndingImageAnimation : MonoBehaviour
{// Dieses Script controlliert die Animation des End Bildes in den EndingSzenes

    // dauer des Ein/Ausblenden
    public float transitionTime;

    // zeit bis beginn des FadeIn 
    public float FadeInStartTime;

    // zeit bis beginn des FadeOut sollte größer FadeInStartTime sein 
    public float FadeOutStartTime;

    // timer welcher die Transition time der Fades steuert. 
    private float timer;
    
    // timer welcher den start der Fades bestimmt
    private float timerFadeIn;

    // bestimmt ob eine Fade Animation läuft
    private bool FadeIsActive;

    // gibt an ob FadeIn abgeschlossen ist. 
    private bool FadeComplete;
    // gibt an ob FadeOut abgeschlossen ist.
    private bool FadeoutComplete;

    // gibt an ob bild sichtbar ist
    private bool isVisible;
    
    // image object welches animiert wird.
    public Image endingImage;
    
    //definition der Farbe für unsichtbar
    private Color Black = Color.black;
    // definition der Farbe für sichtbar
    private Color White = Color.white;

    // geschwindigkeit des zooms
    public float zoomSpeed;
    //maximale zoomstärke
    public float maxZoom;

    // transform componente des endingImage
    private RectTransform rectTransform;

    // gibt an ob zoom aktiv ist
    private bool isZoomingIn = false;

    // Start is called before the first frame update
    void Start()
    {
        // bild ist zu beginn schwarz
        endingImage.color = Black;

        // kein Fade ist zu beginn activ 
        FadeIsActive = false;

        // kein Fade ist zu beginn abgeschlossen
        FadeComplete = false;
        FadeoutComplete = false;

        if (endingImage != null)
        {
            // rectTransform wird Transform componente des endingImage zugewiesen
            rectTransform = endingImage.GetComponent<RectTransform>();
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        // beide timer laufen durchgehend
        timerFadeIn += Time.deltaTime;
        timer += Time.deltaTime;

       


        // wenn der Fade in noch nicht erfolgt ist wird er nach ablauf des FadeInStartTime timers gestarted 
        if(FadeComplete == false)
        {
            if (timerFadeIn >= FadeInStartTime)
            {
            // fadeIn wird gestarted
            fadeIn();
                // zoom wird gestarted
                isZoomingIn = true;
                // fadeComplete wird auf true gesetzt um zu verhindern das sich start wiederhohlt
                FadeComplete = true;
            }
        }

        // wenn der Fade out noch nicht erfolgt ist wird er nach ablauf des FadeOutStartTime timers gestarted 
        if (FadeoutComplete == false)
        {
            if(timerFadeIn >= FadeOutStartTime)
            {
            // fadeOut wird gestarted
            fadeOut();

            // fadeoutComplete wird auf true gesetzt um zu verhindern das sich effekt wiederhohlt
            FadeoutComplete = true;
            }
        }

        // wenn isZoomingIn = true wird der Zoom Gestarted 
        if (isZoomingIn && rectTransform.localScale.x < maxZoom)
        {
            // zoomSpeed bestimmt dabei die geschwindigkeit
            rectTransform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed) * Time.deltaTime;
        }


    // wenn eine FadeIsActive = true und somit eine Fade animation läuft, wird je nach wert von isVisible nun das Bild Ein oder Aus gefaded

        // wenn isVisible == true wird das bild eingeblendet
        if (FadeIsActive == true && isVisible == true)
        {
            // farbe des Bildes wird zu weiß geändert. Bild wird nicht überdeckt und ist sichtbar
            endingImage.color = Color.Lerp(Black, White, timer / transitionTime);

            // transitionTime bestimmt die länge der Blende. Wenn Fade abgeschlossen ist wird FadeIsActive = false gesetzt und die animation gestoppt.
            if (timer >= transitionTime)
            {
                FadeIsActive = false;
            }
        }


        // wenn isVisible == true wird das bild ausgeblendet
        if (FadeIsActive == true && isVisible == false)
        {
            // farbe des bildes wird zu schwarz geändert
            endingImage.color = Color.Lerp(White, Black, timer / transitionTime);

            // transitionTime bestimmt die länge der Blende. Wenn Fade abgeschlossen ist wird FadeIsActive = false gesetzt und die animation gestoppt.
            if (timer >= transitionTime)
            {
                FadeIsActive = false;
            }
        }
    }
    
    // diese funktion started das einblednen des Bildes
    public void fadeIn()
    {
        // timer wird auf 0 gesetzt um das timing mit dem wert der transitionTime abzustimmen. 
        timer = 0.0f;

        // bild zielwert wird auf Sichtbar gesetzt
        isVisible = true;
        // animation wird gestarted 
        FadeIsActive = true;
    }

    // diese funktion started das ausblenden des Bildes
    public void fadeOut()
    {
        // timer wird auf 0 gesetzt um das timing mit dem wert der transitionTime abzustimmen. 
        timer = 0.0f;

        // bild zielwert wird auf Unsichtbar gesetzt
        isVisible = false;
        // animation wird gestarted 
        FadeIsActive = true;
    }
}
