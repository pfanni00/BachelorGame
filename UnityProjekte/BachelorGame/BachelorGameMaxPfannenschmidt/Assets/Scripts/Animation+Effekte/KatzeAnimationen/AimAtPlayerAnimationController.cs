using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimAtPlayerAnimationController : MonoBehaviour
{
    // Dieses Script verändert die Variablen velocityX und velocityZ des Animators, sodass die Katze mit ihrem Blick dem Spieler folgt.
    // Die Berechnung der Werte für die Blickdrehung der Katze findet im Script AimAtPlayerValueCalculator statt.

    // Referenz zum Animator-Component
    Animator animator;
    // Referenz zum GameObject, das den AimAtPlayerValueCalculator-Script enthält
    public GameObject valueCalculator;
    
    // Velocity X und Z sind im Ainmator die x und y Achse eines 2D-Blendtrees welcher die Kopfbewegungsanimationen der Katze Blendet. 
    // Zielwert für die X-Velocity
    private float velocityXTarget;
    // Aktueller Wert für die X-Velocity
    private float velocityX;
    // Zielwert für die Z-Velocity
    private float velocityZTarget;
    // Aktueller Wert für die Z-Velocity
    private float velocityZ; 
    public float speed; // Geschwindigkeit, mit der die Velocity-Werte interpoliert werden

    // Start is called before the first frame update
    void Start()
    {
        velocityX = 0; 
        velocityXTarget = 0; 
        velocityZ = 0; 
        velocityZTarget = 0;
        // Holt die Referenz zum Animator-Component
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Holt die Komponente AimAtPlayerValueCalculator vom valueCalculator GameObject
        AimAtPlayerValueCalculator aimAtPlayerValueCalculator = valueCalculator.GetComponent<AimAtPlayerValueCalculator>();

        // Setzt die Zielwerte für velocityX und velocityZ basierend auf den Prozent Werten  AimAtPlayerValueCalculator
        velocityXTarget = aimAtPlayerValueCalculator.XPercent;
        velocityZTarget = aimAtPlayerValueCalculator.ZPercent;

        // Konvertiert den Prozentwert in den Zielwert für velocityX und Z (VelocityX wird zudem invertiert)
        velocityXTarget = -1 * (velocityXTarget - 0.5f);
        velocityZTarget = velocityZTarget * 0.8f;

        // aktueller wert wird smooth zum zielwert geändert. Speed bestimmt die geschwindigkeit 
        velocityZ = Mathf.Lerp(velocityZ, velocityZTarget, speed * Time.deltaTime);
        // Interpoliert den aktuellen Wert für velocityX zum Zielwert
        velocityX = Mathf.Lerp(velocityX, velocityXTarget, speed * Time.deltaTime);

        // Begrenzung von velocityX auf ihre Maximalwerte
        if (velocityX > 0.5f)
        {
            velocityX = 0.5f;
        }
        if (velocityX < -0.5f)
        {
            velocityX = -0.5f;
        }

        // Begrenzung von velocityZ auf ihre Maximalwerte
        if (velocityZ > 0.8f)
        {
            velocityZ = 0.8f;
        }
        if (velocityZ < 0.45f)
        {
            velocityZ = 0.45f;
        }

        // Setzt die Werte für VelocityX und VelocityZ im Animator
        animator.SetFloat("VelocityX", velocityX);
        animator.SetFloat("VelocityZ", velocityZ);
    }
}