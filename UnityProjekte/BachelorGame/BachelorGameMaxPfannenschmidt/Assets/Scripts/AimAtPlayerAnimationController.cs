using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayerAnimationController : MonoBehaviour
{// dieses Script verändert die variablen velocityX und VelocityZ des Animators so das die Katze mit ihrem Blick dem Spieler folgt. Die Berechnung der Werte für die Blickdrehung der Katze findet im Script AimAtPlayerValueCalculator Statt
    Animator animator;
    public GameObject valueCalculator;
    private float velocityXTarget;
    private float velocityX;
    private float velocityZTarget;
    private float velocityZ;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        velocityX = 0;
        velocityXTarget = 0;
        velocityZ = 0;
        velocityZTarget = 0;
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AimAtPlayerValueCalculator aimAtPlayerValueCalculator = valueCalculator.GetComponent<AimAtPlayerValueCalculator>();
        velocityXTarget = aimAtPlayerValueCalculator.XPercent;
        velocityZTarget = aimAtPlayerValueCalculator.ZPercent;

        // Prozent wird in Wert für velocityX umgerechnet
        velocityXTarget = -1 * (velocityXTarget - 0.5f);

        velocityZTarget = velocityZTarget * 0.8f;


        velocityZ = Mathf.Lerp(velocityZ, velocityZTarget, speed * Time.deltaTime);
        velocityX = Mathf.Lerp(velocityX, velocityXTarget, speed * Time.deltaTime);

        //  velocityX wird auf ihre Maximal werte gesetzt sollte sie diese Überschreiten
        if (velocityX > 0.5f)
        {
            velocityX = 0.5f;
        }
        if (velocityX < -0.5f)
        {
            velocityX = -0.5f;
        }

        // velocityZ wird auf ihre Maximal werte gesetzt sollte sie diese Überschreiten
        if (velocityZ > 0.8f) 
        {
            velocityZ = 0.8f;
        }
        if (velocityZ < 0.45f)
        {
            velocityZ = 0.45f;
        }

        animator.SetFloat("VelocityX", velocityX);
        animator.SetFloat("VelocityZ", velocityZ);
    }
}
