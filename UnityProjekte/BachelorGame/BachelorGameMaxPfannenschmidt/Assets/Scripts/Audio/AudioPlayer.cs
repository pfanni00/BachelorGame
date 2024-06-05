using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // dieses Script kann einen Audioclip nach Ablauf einer Zeit Abspielen.
    public AudioSource Source;
    public AudioClip clip;
    public float timeToPlay; 
    public float timeToStop;
    // Start is called before the first frame update
   
   public void Playaudio()
   {
    StartCoroutine(playAfterSeconds(timeToPlay));
   }

    public void StopAudio()
    {
    StartCoroutine(stopAfterSeconds(timeToStop));
    }

    IEnumerator playAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Source.clip = clip;
        Source.Play();
    }

     IEnumerator stopAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Source.clip = clip;
        Source.Play();
    }

}
