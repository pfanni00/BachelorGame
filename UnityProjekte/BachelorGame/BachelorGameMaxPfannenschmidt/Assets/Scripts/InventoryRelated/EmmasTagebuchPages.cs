using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmasTagebuchPages : MonoBehaviour
{
   // public GameObject Readbutton;

    public GameObject GoNextPage;
    public GameObject GoPreviousPage;
    public GameObject TextSeite1;
    public GameObject TextSeite2;
    public GameObject TextSeite3;
    public AudioSource emmaAudioSource;
    public AudioClip ClipSeite1;
    public AudioClip ClipSeite2;
    public AudioClip ClipSeite3;

    public GameObject ReadButton;
    public GameObject StopButton;
    public bool ReadViewIsOpen;



    private int page;
    // Start is called before the first frame update
    void Start()
    {
    
     page = 1;
    }

   
    // Update is called once per frame
    void Update()
    {
        // Hier wird sichergestellt das bei den ausgewählten pages jeweils der korrekte button für next und Previous Page ein/aus geblendet wird. Die Next/PreviousPage buttons sind nur sichtbar wenn die ReadView geöffnet ist.
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
        {
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

    public void NextPage()
    {
        page = page +1;
        emmaAudioSource.Stop();
        StartCoroutine(PlayEmmasTagebuchAudio(page));
    }

    public void PreviousPage()
    {
        page = page -1;
        emmaAudioSource.Stop();
        StartCoroutine(PlayEmmasTagebuchAudio(page));
    }

    public void ReadButtonClicked()
    {
        ReadViewIsOpen = !ReadViewIsOpen;
        emmaAudioSource.Stop();
        StartCoroutine(PlayEmmasTagebuchAudio(page));
    }


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
