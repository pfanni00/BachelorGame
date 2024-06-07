using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimationStart : MonoBehaviour
{
    // dieses Script started eine Audio Datei anhand eines Parameters in einem Animator.
    // Start is called before the first frame update

    public string Parameter;
    public Animator animator;

    public AudioSource Source;
    public AudioClip clip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetBool(Parameter) == true)
        {
            Source.clip = clip;
            Source.Play();
            Debug.Log("animationStart" + animator.GetBool(Parameter));

        }

        
    }
}
