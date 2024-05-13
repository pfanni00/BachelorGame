using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayerValueCalculator : MonoBehaviour
{
    public GameObject PlayerObj;
    [SerializeField]
    private Vector3 currentPosition;
    [SerializeField]
    private float Xcordinate;
    [SerializeField]
    private float Zcordinate;
    public float XMax;
    public float XMin;
    public float ZMax;
    public float ZMin;
    public float XPercent;
    public float ZPercent;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider PlayerObj)
    {
        // Wenn der Spieler den Collider des Dialog Triggers berührt wird seine Position in diesem ermittelt und die X sowie Z werte jeweils in Prozent umgerechnet. Aus diesen Prozentwerten werden im Script AimAtPlayerAnimationController die Velocity Werte für die Kopfdrehung der Katze berechnet
        currentPosition = PlayerObj.transform.position;
        //Debug.Log(currentPosition);
        Xcordinate = currentPosition.x;
        Zcordinate = currentPosition.z;

        float rangeX = XMax - XMin;
        float currentValueX = XMax - Xcordinate;
        float xpercent = currentValueX / rangeX;
        XPercent = (float)Math.Round(xpercent, 2);
        
        float rangeZ = ZMax - ZMin;
        float currentValueZ = ZMax - Zcordinate;
        float zpercent = currentValueZ / rangeZ;
        ZPercent = (float)Math.Round(zpercent, 2);

        Debug.Log(XPercent);

    }

}
