using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogTrigger : MonoBehaviour
{// dieses Script wird dem KatzeFreeRoamDialogTrigger Object angefügt und started den FreeRoam dialog sobald der Spieler mit dem Object collidiert

// referenz zum Player
public GameObject Playercollider;


// sobald der Spieler den Collider Berührt wird FreeRoamDialog gestarted 
void OnTriggerEnter(Collider Playercollider)
{
    DialogAudioController.Instance.StartFreeRoamDialog();
}

}
