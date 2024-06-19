using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioPlayer : MonoBehaviour
{
    // dieses Script Spielt die Soundeffekte der Türen ab.
    
    // ziel AudioSource
    public AudioSource Source;
    // Clip Tür Öffnen 
    public AudioClip Openclip;
    // Clip Tür Schließen 
    public AudioClip Closeclip;

    // zeit bis der Tür Schließen Clip gespielt wird 
    public float timeToPlayClosed;
    // zeit bis der Tür Öffnen Clip gespielt wird 
    public float  timeToPlayopen;

    // Funktion um TürÖffnen abzuspielen
    public void PlayOpenAudio()
    {
        StartCoroutine(PlayopenSound(timeToPlayopen));
    }

    // Funktion um TürSchließen abzuspielen
    public void PlayCloseAudio()
    {
        StartCoroutine(PlayCloseSound(timeToPlayClosed));
    }

    // Coroutine zum verzögerten abspielen des Öffnen Sounds 
    IEnumerator PlayopenSound(float seconds)
    {
        // eingegebene seconds werden abgewarted 
        yield return new WaitForSeconds(seconds);

        // Audio Clip wird Source zugeteilt
        Source.clip = Openclip;
        // Audio wird abgespielt
        Source.Play();
    }

    // Coroutine zum verzögerten abspielen des Schließen Sounds 
    IEnumerator PlayCloseSound(float seconds)
    {
        // eingegebene seconds werden abgewarted 
        yield return new WaitForSeconds(seconds);

        // Audio Clip wird Source 
        Source.clip = Closeclip;
        // Audio wird abgespielt
        Source.Play();
    }
}
