using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWakeUp : MonoBehaviour
{
        // dieses Script spielt den Initialen dialog und die Blurr animation beim Aufwachen ab.

    // referenz zum volumecontroller
    public GameObject volumeController;

    // Start is called before the first frame update
    void Start()
    {
        // Fadeout Effekt wird gestarted 
         BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.initialFadeOut(); 
        
        //Dialog wird Abgespielt
        DialogAudioController.Instance.PlayDialogueOption(6);
        StartCoroutine(WaitForstartsequenceToEnd());
    }

private IEnumerator WaitForstartsequenceToEnd()
{
//NachAblauf des Dialogs wird der GameState gestarted. Spieler hat jetzt UI und kann mit objecten interagieren 
 yield return new WaitForSeconds(11);
 HUDControlls.Instance.SetGameState();    
}
    
}
