using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmasTagebuchPages : MonoBehaviour
{
   // Dieses Script controlliert die Inventare funktionen von Emmas Tagebuch (Geöffnet) das Item ist besonders da es mehrere Seiten gibt durch die Navigiert werden kann. Außerdem wird ein Voice over Abgespielt

    // Button um auf die Nächste seite zu gelangen
    public GameObject GoNextPage;
    
    //Button um auf die Vorherige Seite zu gelangen
    public GameObject GoPreviousPage;

    // 3 buttons um die reweiligen texte der seiten 1-3 einzublenden 
    public GameObject TextSeite1;
    public GameObject TextSeite2;
    public GameObject TextSeite3;

    // Audio sourde aus der das Voice over abgespielt wird 
    public AudioSource emmaAudioSource;

    // 3 Audio Clips für die 3 Seiten des Tagebuchs
    public AudioClip ClipSeite1;
    public AudioClip ClipSeite2;
    public AudioClip ClipSeite3;

    // Button um die Aktuelle seite zu lesen.
    public GameObject ReadButton;
    // Button um Lesen zu stoppen
    public GameObject StopButton;
    // Variable fragt ab ob Lese View geöffnet ist
    public bool ReadViewIsOpen;
    
    // integer welcher die aktuell gewählte seite bestimmt.
    private int page;


    // Start is called before the first frame update
    void Start()
    {
        // Beim Start wird auf Seite 1 gestarted
     page = 1;
    }

   
    // Update is called once per frame
    void Update()
    {
        // Hier wird sichergestellt das bei den ausgewählten pages jeweils der korrekte button und Text für next und Previous Page ein/aus geblendet wird. Die Next/PreviousPage buttons sind nur sichtbar wenn die ReadView geöffnet ist.
    if(ReadViewIsOpen == true)
    {
        StopButton.SetActive(true);
        ReadButton.SetActive(false);
        if (page == 1)
        {
        GoNextPage.SetActive(true);
        GoPreviousPage.SetActive(false);
        TextSeite1.SetActive(true);
        TextSeite2.SetActive(false);
        TextSeite3.SetActive(false);

        }
        else if (page == 2)
        {
        GoNextPage.SetActive(true);
        GoPreviousPage.SetActive(true);
        TextSeite1.SetActive(false);
        TextSeite2.SetActive(true);
        TextSeite3.SetActive(false);

        }
        else if (page == 3)
        {
        GoPreviousPage.SetActive(true);
        GoNextPage.SetActive(false);
        TextSeite1.SetActive(false);
        TextSeite2.SetActive(false);
        TextSeite3.SetActive(true);

        }
    } else if (ReadViewIsOpen == false)
        {// wenn die Read View geschlossen ist werden alle Buttons und texte bis auf der Read Button Ausgeblendet
            StopButton.SetActive(false);
            ReadButton.SetActive(true);
            GoNextPage.SetActive(false);
            GoPreviousPage.SetActive(false);
            TextSeite1.SetActive(false);
            TextSeite2.SetActive(false);
            TextSeite3.SetActive(false);
            emmaAudioSource.Stop();
        }
       

    }

    // diese funktion ist mit dem GoNextPage button verknüpft 
    public void NextPage()
    {
        // seite wird um 1 erhöht
        page = page +1;
        // Aktueller AudioClip wird abgebrochen neuer Clip der neuen aktuellen seite wird abgespielt
        emmaAudioSource.Stop();
        StartCoroutine(PlayEmmasTagebuchAudio(page));
    }

    // diese funktion ist mit dem GoPreviousPage Button verknüpft
    public void PreviousPage()
    {
        // aktuelle seite -1 
        page = page -1;
        // Aktueller AudioClip wird abgebrochen neuer Clip der neuen aktuellen seite wird abgespielt
        emmaAudioSource.Stop();
        StartCoroutine(PlayEmmasTagebuchAudio(page));
    }

    // diese funktion ist mit dem ReadButton verknüpft
    public void ReadButtonClicked()
    {
        // ReadView wird geöffnet/geschlossen.     
        ReadViewIsOpen = !ReadViewIsOpen;
        // Aktueller AudioClip wird abgebrochen neuer Clip der neuen aktuellen seite wird abgespielt
        emmaAudioSource.Stop();
        StartCoroutine(PlayEmmasTagebuchAudio(page));
    }


    // diese Coroutine spielt das entsprechende voiceOver Audio für die aktuelle page ab.
     private IEnumerator PlayEmmasTagebuchAudio(int currentpage)
    {
        if (currentpage == 1)
        {
            emmaAudioSource.clip = ClipSeite1;
            emmaAudioSource.Play();
        }
        else  if (currentpage == 2)
        {
            emmaAudioSource.clip = ClipSeite2;
            emmaAudioSource.Play();
        }
         else  if (currentpage == 3)
        {
            emmaAudioSource.clip = ClipSeite3;
            emmaAudioSource.Play();
        }
        yield return null;
    }

    


}
