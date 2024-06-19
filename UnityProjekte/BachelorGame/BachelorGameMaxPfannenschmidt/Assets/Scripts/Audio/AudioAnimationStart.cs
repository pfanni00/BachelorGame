using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimationStart : MonoBehaviour
{
    // dieses Script spielt einen AudioClip ab wenn eine bool variable in einem Animator = true gesetzt wird. 
  
    // Parameter der das Abspielen Triggert (muss identisch zum Parameter des Animators sein)
    public string Parameter;

    // link zum animator der den Parameter beinhaltet
    public Animator animator;

    // verzögerungszeit bis die Audio abgespielt wird
    public float timetillStart;

    // ziel AudioSource
    public AudioSource Source;
    // abzuspielender AudioClip
    public AudioClip clip;

    // variable prüft ob Audio bereits abgespielt wurde (erneutes abspielen wird so verhindert)
    private bool AudioisFinished;

    void Start()
    {
        // zu beginn ist die Audio noch nicht gestarted 
        AudioisFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Parameter wird in animator gesucht
        // wenn Parameter = true, wird PlayAudio Coroutine mit timetillStart als verzögerung gestarted 
        if (animator.GetBool(Parameter) == true)
        {
        StartCoroutine(PlayAudio(timetillStart));
        }
    }

    // Coroutine zum abspielen des Audios. 
    IEnumerator PlayAudio(float seconds)
    {
        // eingegebene seconds werden abgewarted 
      yield return new WaitForSeconds(seconds);
         if (AudioisFinished == false)
        {
            // Audio Clip wird Source zugeteilt
            Source.clip = clip;
            // Audio wird abgespielt
            Source.Play();
            // in variable wird status gespeichert
            AudioisFinished = true;
        }
    }

}
