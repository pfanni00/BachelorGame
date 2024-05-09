using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BewegenMitSchublade : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform SchubladeTransform;  // Referenz auf die Transform-Komponente der Schublade

    private Vector3 offset;

    void Start()
    {
        // Berechne den initialen Offset zwischen GameObject und Schublade
        offset = transform.position - SchubladeTransform.position;
    }

    void Update()
    {
        // Aktualisiere die Position des GameObjects, basierend auf der Position der Schublade plus Offset
        transform.position = SchubladeTransform.position + offset;
    }

}
