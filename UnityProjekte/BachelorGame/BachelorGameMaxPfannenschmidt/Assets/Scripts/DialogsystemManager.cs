using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsystemManager : MonoBehaviour
{
    int DialogState;
    bool varianteSD;
    // Controlliert ob variante Schlau oder Dumm aktiv ist.

    bool ItemDialogoptionenAktiv;
    // erlaubt es ItemDialogoptionen 
    GameObject DialogSystemUI;
    GameObject DialogOption1a;
    GameObject DialogOption1b; 
    // Start is called before the first frame update
    void Start()
    {
        DialogState = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
