using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWakeUp : MonoBehaviour
{
        // dieses Script spielt den Initialen dialog und die Blurr animation beim Aufwachen ab.

        public GameObject volumeController;

    // Start is called before the first frame update
    void Start()
    {
         BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.initialFadeOut(); 
        DialogAudioController.Instance.PlayDialogueOption(6);
        StartCoroutine(WaitForstartsequenceToEnd());
    }

private IEnumerator WaitForstartsequenceToEnd()
{
 yield return new WaitForSeconds(11);
 HUDControlls.Instance.SetGameState();    
}
    
}
