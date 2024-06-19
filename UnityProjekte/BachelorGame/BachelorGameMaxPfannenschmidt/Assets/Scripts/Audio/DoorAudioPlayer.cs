using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioPlayer : MonoBehaviour
{
    // dieses Script Spielt die Soundeffekte der T�ren ab.
    
    // ziel AudioSource
    public AudioSource Source;
    // Clip T�r �ffnen 
    public AudioClip Openclip;
    // Clip T�r Schlie�en 
    public AudioClip Closeclip;

    // zeit bis der T�r Schlie�en Clip gespielt wird 
    public float timeToPlayClosed;
    // zeit bis der T�r �ffnen Clip gespielt wird 
    public float  timeToPlayopen;

    // Funktion um T�r�ffnen abzuspielen
    public void PlayOpenAudio()
    {
        StartCoroutine(PlayopenSound(timeToPlayopen));
    }

    // Funktion um T�rSchlie�en abzuspielen
    public void PlayCloseAudio()
    {
        StartCoroutine(PlayCloseSound(timeToPlayClosed));
    }

    // Coroutine zum verz�gerten abspielen des �ffnen Sounds 
    IEnumerator PlayopenSound(float seconds)
    {
        // eingegebene seconds werden abgewarted 
        yield return new WaitForSeconds(seconds);

        // Audio Clip wird Source zugeteilt
        Source.clip = Openclip;
        // Audio wird abgespielt
        Source.Play();
    }

    // Coroutine zum verz�gerten abspielen des Schlie�en Sounds 
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
