using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{// Script Kontrolliert Movement Steuerung 
    
    // Main Camera referenz
    public Camera playerCamera;

    // bewegungsgeschwindigkeit 
    public float walkSpeed = 6f;
    
    // Maus empfindlichkeit beim Umsehen 
    public float lookSpeed = 2f;
    // Maximaler winkel für verticales Umsehen 
    public float lookXLimit = 45f;
 
    // aktuelle richtung in die sich spieler bewegt
    Vector3 moveDirection = Vector3.zero;
    // aktuelle Blickrichtung des Spielers
    float rotationX = 0;
 
    // legt fest ob spieler sich bewegen kann
    public bool canMove = true;
    
    // referenz zum characterController
    CharacterController characterController;
    
    void Start()
    {
        // verbindung zum characterController component wird hergestellt
        characterController = GetComponent<CharacterController>();
        // bewegung wird aktiviert
        unlockMovement();
    }
 
    void Update()
    {
    // Bewegung
        //Vectoren für vorwärts und seitwärts bewegung werden definiert
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        // Geschwindigkeit auf X Achse:
        // Beim vertical axis Input (W/S) bewegt sich der Spieler nach vorne/hinten. walkSpeed bestimmt Geschwindigkeit. Nur möglich wenn canMove = true; 
        float curSpeedX = canMove ?  walkSpeed * Input.GetAxis("Vertical") : 0;

        // Geschwindigkeit auf Y Achse:
        // Beim horizontal axis Input (A/D) bewegt sich der Spieler nach links/rechts. walkSpeed bestimmt Geschwindigkeit. Nur möglich wenn canMove = true; 
        float curSpeedY = canMove ?  walkSpeed * Input.GetAxis("Horizontal") : 0;

        // Geschwindigkeiten X/Y Achse werden verrechnet und ergeben tatsächliche bewegungs richtung/geschwindigkeit des Spielers.
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 
 
        //Move direction wird dem CharakterController hinzugefügt
        characterController.Move(moveDirection * Time.deltaTime);
 
    // Umsehen 
        // nur möglich wenn canMove = true 
        if (canMove)
        {
            //rotationX = vertikale Maus bewegung wird mit geschwindigkeit (lookSpeed) verrechnet
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            // Begrenze die rotationX-Werte, um die Blickrichtung in der X-Achse einzuschränken,
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            // Setze die lokale Rotation der Kamera auf die aktualisierte X-Rotation,
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // horizontale Maus bewegung wird mit geschwindigkeit(lookSpeed) verrechnet. Diese wird jetzt smooth mit der aktuellen rotation multipliziert um so die Korrekte Rotation anzuwenden.
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    
    }

    // Spert das Spieler movement
   public void lockMovement()
    {   
        // Spieler kann sich nicht mehr bewegen
        canMove = false; 
        // Maus kann bewegt werden und ist sichtbar 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    // entsperrt das Spieler movement
  public  void unlockMovement()
    {
        // Spieler kann sich bewegen
        canMove = true;

        // Maus kann nicht bewegt werden und ist unsichtbar 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
 