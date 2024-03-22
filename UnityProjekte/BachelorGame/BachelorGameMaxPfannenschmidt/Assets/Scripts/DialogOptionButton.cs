using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogOptionButton : MonoBehaviour {
	public Button thisButton;
    public GameObject DialogsystemManagerGO;
    public string DOName;
    //Name der Dialogoption die dieser Button Betätigt

	void Awake () {
		Button btn = thisButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        DialogsystemManagerGO = GameObject.Find("DialogsystemManager");

	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
    if (DOName == "DOWarumKannstDuReden")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOWarumKannstDuReden();  
    }
    else if(DOName == "DODasMussEinTraumSein")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDODasMussEinTraumSein();  
    }
    else if(DOName == "DODasIstVerrücktIchMussAufwachen")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDODasIstVerrücktIchMussAufwachen();  
    }
    else if(DOName == "DODannRedeIchJetztMitEinerKatze")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDODannRedeIchWohlMitEinerKatze();  
    }
    else if(DOName == "DOWOIstEmma")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOWoistEmma();  
    }
    else if(DOName == "DOWieBinIchHierhergekommen")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOWieBinIchHierhergekommen();  
    }
    else if(DOName == "DOBinIchTod")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOBinIchTod();  
    }
    else if(DOName == "DOUndWasJetzt")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOUndWasJetzt();  
    }

     else if(DOName == "DOFragNachEmmasTagebuch")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOFragNachEmmasTagebuch();  
    }
     else if(DOName == "DOFütterDieKatze")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOFütterDieKatze();  
    }
    else if(DOName == "DOFragNachEmmasBrief")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOFragNachEmmasBrief();  
    }
    else if(DOName == "DOFragNachKoma")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOFragNachKoma();  
    }
    else if(DOName == "DOIchWäreMeinLebenLangEineLast")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOIchWäreMeinLebenLangEineLast();  
    }
    else if(DOName == "DOIchWillEmmaNichtVerlieren")
    {
        DialogsystemManager DM = DialogsystemManagerGO.GetComponent<DialogsystemManager>();
        DM.SelectDOIchWillEmmaNichtVerlieren();  
    }
    
    Destroy(gameObject);
	}
}