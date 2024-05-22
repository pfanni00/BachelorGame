//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LookAtPlayerRandomAnimation : MonoBehaviour
//{
//    public float state;
//    private int baseState;
//    //public float activateState;
//    private float _timeUntilStart;
//    public float _MintimeToStart;
//    public float _MaxtimetoStart;
//    public Animator animator;
//    [SerializeField]
//    private int _numberOfAnimations;

//    private bool _isActive;
//    private float _AnimationTime;

//    private int _currentAnimation;
    


//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    void Update() 
//    {
//        if (_isActive == false)
//        {
//            //Wenn die Animation InActiv ist, Läuft die AnimationTime ab
//            _AnimationTime += Time.deltaTime;
//           // AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

//            if (_AnimationTime > _timeUntilStart && stateInfo.normalizedTime % 1 < 0.02f)
//            {
//                _isActive = true;

//                state = Random.Range(1, _numberOfAnimations);
//               // _currentAnimation = _currentAnimation * 2 - 1;
//                baseState = 5;
//                animator.SetFloat("AimAtPlayerAnimations", state);
//            }
//        }
//        else if (stateInfo.normalizedTime % 1 > 0.98)
//        {
//            ResetAnimation();
//        }

//        //animator.SetFloat(state, _currentAnimation, 0.2f, Time.deltaTime);
//        animator.SetBool("AnimationisPlaying", _isActive);

//        animator.SetInteger("BaseState", baseState);
//    }

//    private void ResetAnimation()
//    {
//        /*if (_isActive)
//        {
//            // _currentAnimation--;
//        }*/

//        _isActive = false;
//        _AnimationTime = 0;
//            baseState = 4;
//        //_timeUntilStart = Random.Range(_MintimeToStart, _MaxtimetoStart);
//        // baseState = 4;
//    }

//}
