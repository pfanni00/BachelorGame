using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayerAnimationController : MonoBehaviour
{
    Animator animator;
    public GameObject valueCalculator;
    private float velocityxTarget;
    private float velocityx;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        velocityx = 0;
        velocityxTarget = 0;
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AimAtPlayerValueCalculator aimAtPlayerValueCalculator = valueCalculator.GetComponent<AimAtPlayerValueCalculator>();
        velocityxTarget = aimAtPlayerValueCalculator.XPercent;
        velocityxTarget = -1 * (velocityxTarget - 0.5f);

        if(velocityx < velocityxTarget )
            {
            velocityx += velocityxTarget * speed;
            }
        else if (velocityx > velocityxTarget ) 
            {  
            velocityx -= velocityxTarget * speed; 
            }
       // velocityx = Mathf.Lerp(velocityx, velocityxTarget, speed * Time.deltaTime);
    
    animator.SetFloat("VelocityX", velocityx);
    }
}
