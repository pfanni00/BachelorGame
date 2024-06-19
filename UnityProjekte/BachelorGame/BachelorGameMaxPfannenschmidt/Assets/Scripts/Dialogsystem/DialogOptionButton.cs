using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogOptionButton : MonoBehaviour {
    // dieses Script wird auf die Buttons des Dialogsystems gelegt und sorgt dafür das beim Clicken die Korrekte SelectDO[Dialogoption] im DialogsystemManager gestarted wird
	
    // referenz zum Button 
    public Button thisButton;

    //Name der Dialogoption die dieser Button Betätigt
    public string DOName;



	void Awake () 
    {
        // verbindung zum Button Component wird hergestellt
		Button btn = thisButton.GetComponent<Button>();
        // Listener für on Click wird definiert
		btn.onClick.AddListener(TaskOnClick);
	}

	// Je nach DOName wir hier die richtige Funktion im DialogsystemManager gestarted 
    void TaskOnClick()
    {
		Debug.Log ("You have clicked the button!");
    if (DOName == "DOWarumKannstDuReden")
    {
        DialogsystemManager.Instance.SelectDOWarumKannstDuReden();  
    }
    else if(DOName == "DODasMussEinTraumSein")
    {
        DialogsystemManager.Instance.SelectDODasMussEinTraumSein();  
    }
    else if(DOName == "DODasIstVerrücktIchMussAufwachen")
    {
        DialogsystemManager.Instance.SelectDODasIstVerrücktIchMussAufwachen();  
    }
    else if(DOName == "DODannRedeIchJetztMitEinerKatze")
    {
        DialogsystemManager.Instance.SelectDODannRedeIchWohlMitEinerKatze();  
    }
    else if(DOName == "DOWOIstEmma")
    {
        DialogsystemManager.Instance.SelectDOWoistEmma();  
    }
    else if(DOName == "DOWieBinIchHierhergekommen")
    {
        DialogsystemManager.Instance.SelectDOWieBinIchHierhergekommen();  
    }
    else if(DOName == "DOBinIchTod")
    {
        DialogsystemManager.Instance.SelectDOBinIchTod();  
    }
    else if(DOName == "DOUndWasJetzt")
    {
        DialogsystemManager.Instance.SelectDOUndWasJetzt();  
    }

     else if(DOName == "DOFragNachEmmasTagebuch")
    {
        DialogsystemManager.Instance.SelectDOFragNachEmmasTagebuch();  
    }
     else if(DOName == "DOFütterDieKatze")
    {
        DialogsystemManager.Instance.SelectDOFütterDieKatze();  
    }
    else if(DOName == "DOFragNachEmmasBrief")
    {
        DialogsystemManager.Instance.SelectDOFragNachEmmasBrief();  
    }
    else if(DOName == "DOFragNachKoma")
    {
        DialogsystemManager.Instance.SelectDOFragNachKoma();  
    }
    else if(DOName == "DOIchWäreMeinLebenLangEineLast")
    {
        DialogsystemManager.Instance.SelectDOIchWäreMeinLebenLangEineLast();  
    }
    else if(DOName == "DOIchWillEmmaNichtVerlieren")
    {
        DialogsystemManager.Instance.SelectDOIchWillEmmaNichtVerlieren();  
    }
    
    // gameObject wird gelöscht
    Destroy(gameObject);
	}
}