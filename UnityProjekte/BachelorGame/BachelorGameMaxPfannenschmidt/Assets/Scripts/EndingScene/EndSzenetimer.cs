using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSzenetimer : MonoBehaviour
{// dieses Script lädt das Hauptmenü nachdem die EndingSzene Abgeschlossen ist

    // zeit bis hauptmenu geladen wird 
    public float SequenceDuration;

    
    private float timer;

    // Update is called once per frame
    void Update()
    {
        // timer läuft ab start 
        timer += Time.deltaTime;

        // wenn der timer die SequenceDuration erreicht wird das Hauptmenü geladen
        if (timer >= SequenceDuration)
        {
            GameManager.Instance.LoadMainMenu();
        }

    }
}
