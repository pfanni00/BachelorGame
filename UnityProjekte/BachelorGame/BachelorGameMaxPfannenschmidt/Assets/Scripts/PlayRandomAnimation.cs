using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAnimation : StateMachineBehaviour
{
    public string state;
    //public float activateState;
    private float _timeUntilStart;
    public float _MintimeToStart;
    public float _MaxtimetoStart;

    [SerializeField]
    private int _numberOfAnimations;

    private bool _isActive;
    private float _AnimationTime;

    private int _currentAnimation;
  //  OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetAnimation();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_isActive == false) 
        {
            //Wenn die Animation InActiv ist, Läuft die AnimationTime ab
            _AnimationTime += Time.deltaTime;

            if(_AnimationTime > _timeUntilStart && stateInfo.normalizedTime % 1 < 0.02f) 
            {
            _isActive = true;

                _currentAnimation = Random.Range(1, _numberOfAnimations + 1);
                _currentAnimation = _currentAnimation * 2 - 1;

                animator.SetFloat(state, _currentAnimation - 1);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetAnimation();
        }

        animator.SetFloat(state, _currentAnimation, 0.2f, Time.deltaTime);
    
      
    }

    private void ResetAnimation()
    {
        if (_isActive)
        {
            _currentAnimation--;
        }

        _isActive = false;
        _AnimationTime = 0;
        _timeUntilStart = Random.Range(_MintimeToStart, _MaxtimetoStart);
    }

}
