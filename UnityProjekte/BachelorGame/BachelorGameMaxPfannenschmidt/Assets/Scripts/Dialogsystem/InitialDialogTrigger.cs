using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogTrigger : MonoBehaviour
{
public GameObject Playercollider;

void OnTriggerEnter(Collider Playercollider)
{
    Debug.Log("HEYDU");
    DialogAudioController.Instance.StartFreeRoamDialog();
}

}
