using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsystemManager : MonoBehaviour
{
    public static DialogsystemManager Instance;
    
    public int DialogState;
    private bool varianteSD;
    // Controlliert ob variante Schlau oder Dumm aktiv ist.
    private bool DOPrefabsareSpawned;
    public GameObject DialogSystemUI;
    public Transform DOParent;
    public GameObject Katze;
    public bool AlldialogisFinished;

    public Animator katzeanimator;
    public GameObject Thunfischdose;

    // DO sind die Prefabs der DialogoptionButtons im UI
    public GameObject DOWarumKannstDuReden;
    public GameObject DODasMussEinTraumSein; 
    public GameObject DODasIstVerrücktIchMussAufwachen;
    public GameObject DODannRedeIchJetztMitEinerKatze;
    public GameObject DOWOIstEmma;
    public GameObject DOWieBinIchHierhergekommen;
    public GameObject DOBinIchTod;
    public GameObject DOUndWasJetzt;
    public GameObject DOFragNachEmmasTagebuch;
    public GameObject DOFütterDieKatze;
    public GameObject DOFragNachEmmasBrief;
    public GameObject DOFragNachKoma;
    public GameObject DOIchWäreMeinLebenLangEineLast;
    public GameObject DOIchWillEmmaNichtVerlieren;

    public GameObject LeaveButton;

    // Items welche mit Dialogsystem Interagieren
    public Item EmmasTagebuch;
    public Item BriefanMama;
    public Item Patientenakte;
    public Item Tunfischdose;

    // Bools für die Dialogoptionen welche das sammeln von Items als bedingung haben. Sie prüfen ob Die Dialogoptionen bereits gespawned wurden
    
    private bool DOFragNachEmmasTagebuchIsSpawned;
    private bool DOFragNachKomaIsSpawned;
    private bool DOFütterDieKatzeIsSpawned;
    private bool DOFragNachEmmasBriefIsSpawned;

    // Da die ItemBedingten Dialoge über mehrere Dialogstates gespant werden können muss zudem geprüft werden ob sie bereits Selectiert wurden

    private bool DOFragNachEmmasBriefWasSelected;
    private bool DOFragNachEmmasTagebuchWasSelected;
    private bool DOFütterDieKatzeWasSelected;
    



    // Start is called before the first frame update
    
    
        private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DialogState = 1;
        DOPrefabsareSpawned = false; 
        DOFragNachKomaIsSpawned = false;
        DOFütterDieKatzeIsSpawned = false;
        DOFragNachEmmasTagebuchIsSpawned = false;
        DOFragNachEmmasBriefIsSpawned = false;
        LeaveButton.SetActive(false);
        AlldialogisFinished = false;

        Thunfischdose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // wenn Dialog Gespielt wird wird das UI Ausgeblendet
        if (DialogAudioController.Instance.AudioisActive == true)
        {
            DialogSystemUI.SetActive(false);
        }else if (DialogAudioController.Instance.AudioisActive == false)
        {
            DialogSystemUI.SetActive(true);
        }


        //in den Ersten Drei Phasen des Dialogs sind jeweils 2 Dialogoptionen verfügbar
        if(DialogState == 1 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DOWarumKannstDuReden, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DODasMussEinTraumSein, DOParent) as GameObject;
        DOPrefabsareSpawned = true;
        }
        
        if (DialogState == 2 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DODannRedeIchJetztMitEinerKatze, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DODasIstVerrücktIchMussAufwachen, DOParent) as GameObject;
        DOPrefabsareSpawned = true;

        }
        
        if (DialogState == 3 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DOWOIstEmma, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DOWieBinIchHierhergekommen, DOParent) as GameObject;
        DOPrefabsareSpawned = true;

        }


        // In Phase 4 sind 2 weitere Dialogoptionen verfügbar die jedoch nicht die Phaen voranschreiten lassen. Ein Leave Button wird ebenfalls hinzugefügt.
        // Zudem sind 4 Item Abhängige Dialogoptionen verfügbar. DOFragNachKoma lässt den DialogState weiter voranschreiten die Anderen DOs sind jetzt in jeder weiteren Phase verfügbar
        
        if (DialogState == 4)
        {
        
            if (DOPrefabsareSpawned == false)
                {
                GameObject DO1 = Instantiate(DOBinIchTod, DOParent) as GameObject;
                GameObject DO2 = Instantiate(DOUndWasJetzt, DOParent) as GameObject;
                DOPrefabsareSpawned = true;
                }  
            if (InventarManager.Instance.Items.Contains(Patientenakte) && DOFragNachKomaIsSpawned == false)
                {
                GameObject DO5 = Instantiate(DOFragNachKoma, DOParent) as GameObject;
                DOFragNachKomaIsSpawned = true;
                }
        }
        
        if (DialogState == 4 || DialogState == 6)
        {
            LeaveButton.SetActive(true);

            if (InventarManager.Instance.Items.Contains(BriefanMama) && DOFragNachEmmasBriefIsSpawned == false && DOFragNachEmmasBriefWasSelected == false)
                {
                GameObject DO3 = Instantiate(DOFragNachEmmasBrief, DOParent) as GameObject;
                DOFragNachEmmasBriefIsSpawned = true;
                }
            if (InventarManager.Instance.Items.Contains(EmmasTagebuch) && DOFragNachEmmasTagebuchIsSpawned == false & DOFragNachEmmasTagebuchWasSelected == false)
                {
                GameObject DO4 = Instantiate(DOFragNachEmmasTagebuch, DOParent) as GameObject;
                DOFragNachEmmasTagebuchIsSpawned = true;
                }

            if (InventarManager.Instance.Items.Contains(Tunfischdose) && DOFütterDieKatzeIsSpawned == false && DOFragNachEmmasTagebuchWasSelected == true && DOFütterDieKatzeWasSelected == false)
                {
                GameObject DO6 = Instantiate(DOFütterDieKatze, DOParent) as GameObject;
                DOFütterDieKatzeIsSpawned = true;
                }
                
        }
            
            
            
        
        // Phase 5 beinhaltet 2 weitere Dialogoptionen. Item Dialogoptionen sind hier Pausiert und erst in Phase 6 wieder Wählbar

        if (DialogState == 5 && DOPrefabsareSpawned == false)
        {
        LeaveButton.SetActive(false);
        GameObject DO1 = Instantiate(DOIchWillEmmaNichtVerlieren, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DOIchWäreMeinLebenLangEineLast, DOParent) as GameObject;
        DOPrefabsareSpawned = true;
        }

        // Wenn Alle DialogStates Abgeschlossen sind und keine Itembedingten DOs mehr verfügbar sind wird die interaktionsmöglichkeit mit der Katze Deaktiviert.
        if (DialogState == 6)
        {
            if (DOFragNachEmmasBriefWasSelected == true && DOFragNachEmmasTagebuchWasSelected == true && DOFütterDieKatzeWasSelected == true)
            {
                /*KatzeInteraction ki = Katze.GetComponent<KatzeInteraction>();
                ki.MakeUnusable(); */
                AlldialogisFinished = true;
            }
        }
    }

// Diese Methode erhöht den DialogState um jeweils 1 

    private void NextDialogState()
    {
         foreach (Transform child in DOParent)
    {
        Destroy(child.gameObject);
    }

    DOPrefabsareSpawned = false;
    DOFragNachEmmasBriefIsSpawned = false;
    DOFragNachEmmasTagebuchIsSpawned = false;
    DOFütterDieKatzeIsSpawned = false;
        DialogState = DialogState +1;
    }

    private IEnumerator StartAudioAfterSeconds(float seconds)
    {
        // animation wird nach Sekundenzahl gestarted 
        yield return new WaitForSeconds(seconds);
        DialogAudioController.Instance.PlayDialogueOption(3);
    }

    private IEnumerator StartAnimationAfterSeconds(float seconds, int animationState)
    {
        // animation wird nach Sekundenzahl gestarted 
        yield return new WaitForSeconds(seconds);
        katzeanimator.SetInteger("BaseStates", animationState);

    }


    //Dialogoptionen der ersten Phase: 
    public void SelectDOWarumKannstDuReden()
    {
        DialogAudioController.Instance.PlayDialogueOption(1);
        NextDialogState(); 

    }

   public void SelectDODasMussEinTraumSein()
    {
        DialogAudioController.Instance.PlayDialogueOption(2);
        NextDialogState();    
    }

    //Dialogoptionen der zweiten Phase: 
   public void SelectDODannRedeIchWohlMitEinerKatze()
    {
        //Audio is Played in another Script
        //Katze Hält Marcell für schlau
        varianteSD = true;
        NextDialogState();    
    }

   public void SelectDODasIstVerrücktIchMussAufwachen()
    {
        //Audio is Played in another Script
        //Katze Hält Marcell für dumm
        varianteSD = false;
        NextDialogState();    
    }

//Dialogoptionen der Dritten Phase:

   public void SelectDOWoistEmma()
    {
        //Audio is Played in another Script 
        NextDialogState();    
    }

   public void SelectDOWieBinIchHierhergekommen()
    {
        //Audio is Played in another Script 
        NextDialogState();    
    }
    
//Dialogoptionen der Vierten Phase:

   public void SelectDOBinIchTod()
    {
        //AudioIstPlayed
    }

    public void SelectDOUndWasJetzt()
    {
        //AudioIstPlayed
    }

     public void SelectDOFragNachEmmasTagebuch()
    {
        //AudioIstPlayed
        //Katze bittet um Essen wenn der Spieler die Tunfischdose hat kann er sie nun der Katze geben.
        DOFragNachEmmasTagebuchWasSelected = true;
    }
     public void SelectDOFütterDieKatze()
    {
        Thunfischdose.SetActive(true);

        katzeanimator.SetInteger("BaseStates", 3);
        StartCoroutine(StartAudioAfterSeconds(6.5f));
        StartCoroutine(StartAnimationAfterSeconds(14f,2));
        DOFütterDieKatzeWasSelected = true;
    }
    public void SelectDOFragNachEmmasBrief()
    {
        //AudioIstPlayed
        DOFragNachEmmasBriefWasSelected = true;
    }
     public void SelectDOFragNachKoma()
    {
        //AudioIstPlayed
        NextDialogState();
    }
     public void SelectDOIchWäreMeinLebenLangEineLast()
    {
        //AudioIstPlayed
        NextDialogState();
    }
     public void SelectDOIchWillEmmaNichtVerlieren()
    {
        //AudioIstPlayed
        NextDialogState();

    }


}
