using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoopPlayer : MonoBehaviour
{
    // Dieses Script kann einen loop AudioClip Abspielen und Stoppen

    // zielaudio Source
    public AudioSource Source;
    // abzuspielender Clip
    public AudioClip clip;

    // verzögerung bis Audio gestarted wird
    public float timeToPlay;

    // verzögerung bi Audio gestoppt wird 
    public float timeToStop;

    // variable zeigt an ob audio Active ist 
    private bool isActive;

    // Funktio um Audio Loop zu Starten 
    public void Playaudio()
    { 
    StartCoroutine(playAfterSeconds(timeToPlay));
    }

    // Funktio um Audio Loop zu stoppen
    public void StopAudio()
    {
    StartCoroutine(stopAfterSeconds(timeToStop));
    }

    // Coroutine um Audio nach einer Sekundenzahl zu starten Secundenzahl wird in Playaudio() angegeben 
    IEnumerator playAfterSeconds(float seconds)
    {
        // eingegebene seconds werden abgewarted 
        yield return new WaitForSeconds(seconds);
        // Audio Clip wird Source zugeteilt
        Source.clip = clip;
        // Audio wird abgespielt
        Source.Play();
    }
    
    // Coroutine um Audio nach secundenzahl zu stoppen 
     IEnumerator stopAfterSeconds(float seconds)
    {
        // eingegebene seconds werden abgewarted 
        yield return new WaitForSeconds(seconds);
        // Audio wird gestoppt    
        Source.Stop();
    }

}
