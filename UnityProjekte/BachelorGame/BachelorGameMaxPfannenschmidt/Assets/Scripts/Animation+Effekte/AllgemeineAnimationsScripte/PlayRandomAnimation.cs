using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAnimation : StateMachineBehaviour
{// dieses Script spielt im loop zufällige animatioen ab. Es wird für Idle animationen der Katze genutzt. 

    // diese variable wird genutzt um die int variable des Animators zu finden welche bestimmt welche zufalls animation abgespielt wird 
    public string state;
    // zeit bis nächste zufalls animation gespielt wird. wert wird aus _MintimeToStart und _MaxtimetoStart berechnet 
    private float _timeUntilStart;

    // minimale zeit bis nächste zufalls animation gespielt wird 
    public float _MintimeToStart;
    // maximale zeit bis nächste zufalls animation gespielt wird 
    public float _MaxtimetoStart;

    // anzahl der zufallsanimationen
    private int _numberOfAnimations;

    // zeigt an ob eine zufalls animation läuft 
    private bool _isActive;

    // timer zum abspielen der Zufalls animation 
    private float _AnimationTime;

    // aktuelle zufallsanimation entpricht state Value.
    private int _currentAnimation;


  //  OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Zurücksetzen der Animation und Initialisierung der Variablen
        ResetAnimation();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_isActive == false) 
        {
            //Wenn die Animation InActiv ist, Läuft die AnimationTime ab
            _AnimationTime += Time.deltaTime;

            // Wenn die Zeit bis zur nächsten Animation abgelaufen ist und die aktuell laufende Animation nahe am Übergang ist, wird Zufalls Animation abgespielt 
            if (_AnimationTime > _timeUntilStart && stateInfo.normalizedTime % 1 < 0.02f) 
            {
            //Animation wird Gestarted 
            _isActive = true;

                //  zufalls animation wird ausgewählt 
                _currentAnimation = Random.Range(1, _numberOfAnimations + 1);
                _currentAnimation = _currentAnimation * 2 - 1;

                // ausgewählte animation wird im Animator gesetzt 
                animator.SetFloat(state, _currentAnimation - 1);
            }
        }
        // Wenn die Animation fast vorbei ist, wird sie zurückgesetzt
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetAnimation();
        }

        animator.SetFloat(state, _currentAnimation, 0.2f, Time.deltaTime);
        animator.SetBool("AnimationisPlaying",  _isActive);
    
      
    }

    private void ResetAnimation()
    {
        // Wenn eine Animation aktiv ist, wird die aktuelle Animation um eins reduziert so kehrt die katze zurück in den Idle state 
        if (_isActive)
        {
            _currentAnimation--;
        }

        //Animation wird inactiv gesetzt 
        _isActive = false;

        //timer wird zurückgesetzt
        _AnimationTime = 0;

        // neue zeit bis zum start wird berechnet 
        _timeUntilStart = Random.Range(_MintimeToStart, _MaxtimetoStart);
    }

}
