using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogsystemLeaveButton : MonoBehaviour {
	public Button thisButton;
    public GameObject Player;
    //Name der Dialogoption die dieser Button Betätigt

	void Awake () {
		Button btn = thisButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick()
    {
        HUDControlls hc = Player.GetComponent<HUDControlls>();
        hc.closeDialogsystem(); 
	}
}