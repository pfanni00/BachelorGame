using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    // dieses Script wird dem KatteDialogTrigger Object angefügt und stellt fest ob der Spieler sich in dem Collider befindet 
    // Der Collider wird vor der Katze Plaziert. Der Spieler kann nur mit der Katze Sprechen wenn er den Collider Berührt so wird sichergestellt, dass er die Katze bei den Dialogen von Forne Ansieht 

// referenz zum Player
public GameObject Playercollider;

// variable die anzeigt ob der Collider vom Spieler berührt wird
public bool TriggerActive;

void Start ()
{
     // zum start wird der Collider nicht berührt
    TriggerActive = false;
}


void OnTriggerEnter(Collider Playercollider)
{
    //sobald der Spieler den Collider berührt wird TriggerActive = true gesetzt 
    TriggerActive = true;
    //Katzen Animation verändert sich (nur bevor Dialog gestarted wurde)
    KatzeAnimationsController.Instance.StartAnimationState(TriggerActive);
}

void OnTriggerExit(Collider Playercollider)
{
    //sobald der Spieler den Collider verlässt wird TriggerActive = false gesetzt 
    TriggerActive = false;
    //Katzen Animation verändert sich (nur bevor Dialog gestarted wurde)
    KatzeAnimationsController.Instance.StartAnimationState(TriggerActive);

    }

}
