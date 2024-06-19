using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogsystemLeaveButton : MonoBehaviour {
	// funktion des Leave Buttons des Dialogsystems 

	// button Object 
	public Button thisButton;



	void Awake () 
	{
        // verbindung zum Button Component wird hergestellt
        Button btn = thisButton.GetComponent<Button>();
        // Listener für on Click wird definiert
        btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
    {
	// dialogsystem wird geschlossen 
      HUDControlls.Instance.closeDialogsystem(); 
	}
}