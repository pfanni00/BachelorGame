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
    public float XPercent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerStay(Collider PlayerObj)
    {
        currentPosition = PlayerObj.transform.position;
        //Debug.Log(currentPosition);
        Xcordinate = currentPosition.x;
        //Zcordinate = currentPosition.z;

        float range = XMax - XMin;
        float currentValue = XMax - Xcordinate;
        float xpercent = currentValue / range;
        XPercent = (float)Math.Round(xpercent, 2);

        Debug.Log(XPercent);

    }

}
