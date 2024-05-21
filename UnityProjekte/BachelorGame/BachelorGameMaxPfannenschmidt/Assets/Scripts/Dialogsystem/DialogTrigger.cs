using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
public GameObject Playercollider;
public bool TriggerActive;
// Der Collider wird vor der Katze Plaziert. Der Spieler kann nur mit der Katze Sprechen wenn er den Collider Berührt so wird sichergestellt, dass er die Katze bei den Dialogen von Forne Ansieht 

void Start ()
{
    TriggerActive = false;
}


void OnTriggerEnter(Collider Playercollider)
{
    TriggerActive = true;
    KatzeAnimationsController.Instance.StartAnimationState(TriggerActive);
}

void OnTriggerExit(Collider Playercollider)
{
    TriggerActive = false;
    KatzeAnimationsController.Instance.StartAnimationState(TriggerActive);

    }

}
