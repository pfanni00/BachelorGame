using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogTrigger : MonoBehaviour
{
public GameObject Playercollider;
// Der Collider wird hinter der Tür zum Wohnzimmer Plaziert und löst den Free Roam Dialog aus bei welchem die Katze nach dem Spieler Ruft. 
void OnTriggerEnter(Collider Playercollider)
{
    Debug.Log("HEYDU");
    DialogAudioController.Instance.StartFreeRoamDialog();
}

}
