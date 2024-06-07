using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimationStart : MonoBehaviour
{
    // dieses Script started eine Audio Datei anhand eines Parameters in einem Animator.
    // Start is called before the first frame update

    public string Parameter;
    public Animator animator;
    public float timetillStart;
    public AudioSource Source;
    public AudioClip clip;
    private bool AudioisFinished;

    void Start()
    {
        AudioisFinished = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetBool(Parameter) == true)
        {
    
        StartCoroutine(PlayAudio(timetillStart));
    

       
           
        }

        
    }

    IEnumerator PlayAudio(float seconds)
    {
       yield return new WaitForSeconds(seconds);
         if (AudioisFinished == false)
        {
            Source.clip = clip;
            Source.Play();
            Debug.Log("animationStart" + animator.GetBool(Parameter));
            AudioisFinished = true;
        }
    }

}
