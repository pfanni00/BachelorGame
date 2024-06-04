using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioPlayer : MonoBehaviour
{
    // dieses Script kann einen Audioclip nach Ablauf einer Zeit Abspielen.
    public AudioSource Source;
    public AudioClip Openclip;
    public AudioClip Closeclip;
    public float timeToPlayClosed;
    public float  timeToPlayopen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOpenAudio()
    {
        StartCoroutine(PlayopenSound(timeToPlayopen));
    }


     public void PlayCloseAudio()
    {
        StartCoroutine(PlayCloseSound(timeToPlayClosed));
    }

    IEnumerator PlayopenSound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Source.clip = Openclip;
        Source.Play();
    }

       IEnumerator PlayCloseSound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Source.clip = Closeclip;
        Source.Play();
    }
}
