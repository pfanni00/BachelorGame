using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayerValueCalculator : MonoBehaviour
{
    // Referenz zum Player 
    public GameObject PlayerObj;
    
    // zu ermittelnde Position des Players 
    private Vector3 currentPosition;
    // zu ermittelnde X Position des Players
    private float Xcordinate;
    // zu ermittelnde Z Position des Players 
    private float Zcordinate;

    // Maximal und Minimal werte der X und Z Positionen 
    public float XMax;
    public float XMin;
    public float ZMax;
    public float ZMin;

    // X und Z cordinate in Prozent 
    public float XPercent;
    public float ZPercent;


    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider PlayerObj)
    {// Wenn der Spieler den Collider des Dialog Triggers berührt wird seine Position in diesem ermittelt und die X sowie Z werte jeweils in Prozent umgerechnet. Aus diesen Prozentwerten werden im Script AimAtPlayerAnimationController die Velocity Werte für die Kopfdrehung der Katze berechnet

        // Player Position wird ermittelt
        currentPosition = PlayerObj.transform.position;

        // x und z coordinate der Position werden ermittelt 
        Xcordinate = currentPosition.x;
        Zcordinate = currentPosition.z;

        //Werte werden in Prozent umgerechnet. 
        float rangeX = XMax - XMin;
        float currentValueX = XMax - Xcordinate;
        float xpercent = currentValueX / rangeX;
        XPercent = (float)Math.Round(xpercent, 2);
        
        float rangeZ = ZMax - ZMin;
        float ZMaxPercent = ZMin * -1;
        float currentValueZ = ZMaxPercent + Zcordinate;
        float zpercent = currentValueZ / rangeZ;
        ZPercent = (float)Math.Round(zpercent, 2);


    }

}
