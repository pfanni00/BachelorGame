using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // dieses Script kann einen Audioclip nach Ablauf einer Zeit Abspielen.
    public AudioSource Source;
    public AudioClip clip;
    public float timeToPlay; 
    // Start is called before the first frame update
   
   void Playaudio()
   {
    StartCoroutine(playAfterSeconds(timeToPlay));
   }

    IEnumerator playAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Source.clip = clip;
        Source.Play();
    }
}
