using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsystemManager : MonoBehaviour
{// dieses Script managed das Dialogsystem

    public static DialogsystemManager Instance;

    // gibt an ob Dialogsystem nutzbar ist
    public bool DialogsystemIsUsabale;

    // DialogState ist status des Dialogsystems diese variable ist wichtig um das korrekte laden der DialogOptionen zu gewährleisten 
    public int DialogState;

    // gibt an ob bereits alle Dialogoptionen Abgespielt wurden 
    public bool AlldialogisFinished;

    //gibt an ob die GetKey animation eingeleitet wurde
    private bool GetKeySequenceWasPlayed;

    // Controlliert ob variante Schlau oder Dumm aktiv ist.
    private bool varianteSD;
    
    // gibt an ob die Dialogoptionen Prefabs gespawned sind. So wird sichergestellt das pro dialogState die Dialogoptionen nur einmal gespawned werden 
    private bool DOPrefabsareSpawned;
    // UI Parent des Dialogsystems
    public GameObject DialogSystemUI;
    // Parend der Dialogoptionen hier werden die DO prefabs gespawned
    public Transform DOParent;

    // referenz zur Katze
    public GameObject Katze;

    // referenz zum Player
    public GameObject Player;

    // Animator der Katze 
    public Animator katzeanimator;

    // World Item object der Thunfischdose
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

    // UI Button um das Dialogsystem zu verlassen 
    public GameObject LeaveButton;

    // Items welche mit Dialogsystem Interagieren dienen als bedingungen für die freischaltung von Dialogoptionen 
    public Item EmmasTagebuch;
    public Item BriefanMama;
    public Item Patientenakte;
    public Item Tunfischdose;

    // Bools für die Dialogoptionen welche das sammeln von Items als bedingung haben. Sie prüfen ob Die Dialogoptionen bereits gespawned wurden
    
    private bool DOFragNachEmmasTagebuchIsSpawned;
    private bool DOFragNachKomaIsSpawned;
    private bool DOFütterDieKatzeIsSpawned;
    private bool DOFragNachEmmasBriefIsSpawned;

    // Da die ItemBedingten Dialoge über mehrere Dialogstates spawnen können muss zudem geprüft werden ob sie bereits Selectiert wurden
    private bool DOFragNachEmmasBriefWasSelected;
    private bool DOFragNachEmmasTagebuchWasSelected;
    private bool DOFütterDieKatzeWasSelected;
    
    
    
    private void Awake()
    {
        Instance = this;
    }

    
    void Start()
    {
        // dialogsystem ist zum start nutzbar
        DialogsystemIsUsabale = true;

        DialogState = 1;

        // GetKey animation wurde noch nicht gespielt 
        GetKeySequenceWasPlayed = false;

        // Prefabs sind noch nicht gespawned 
        DOPrefabsareSpawned = false; 
        DOFragNachKomaIsSpawned = false;
        DOFütterDieKatzeIsSpawned = false;
        DOFragNachEmmasTagebuchIsSpawned = false;
        DOFragNachEmmasBriefIsSpawned = false;

        // leave button ist nicht verfügbar 
        LeaveButton.SetActive(false);

        // Thunfischdose ist nicht sichtbar 
        Thunfischdose.SetActive(false);

        // es wurden noch nicht alle dialogoptionen angewählt 
        AlldialogisFinished = false;

    }

    // Update is called once per frame
    void Update()
    {
           // wenn die Katze den Spieler nicht ansieht ist das DialogSystemUI ausgeblendet. Bug Fix, ohne diese Funkion kann katze in AnimationStates freezen wenn Dialogoptionen ausgewählt werden während andere Animation läuft
        if (katzeanimator.GetBool("AimisActive") == false)
        {
            DialogSystemUI.SetActive(false);
        }
      
    

        // wenn Dialog audio  abgespielt wird, ist das UI Ausgeblendet
        if (DialogAudioController.Instance.AudioisActive == true)
        {
            DialogSystemUI.SetActive(false);
        }else if (DialogAudioController.Instance.AudioisActive == false && DialogsystemIsUsabale == true && katzeanimator.GetBool("AimisActive") == true)
        {
            DialogSystemUI.SetActive(true);
        }

        // wenn die Fütter Animation der Katze endet wird automatisch der darauffolgende Dialog und die Animation mit welcher der Spieler den Schlüssel erhält abgespielt. 
        bool EatingAnimationIsOver = katzeanimator.GetBool("EatingAnimationIsfinished");
        if(EatingAnimationIsOver == true && GetKeySequenceWasPlayed == false)
        {
            //GetKey Animation wird gestarted. dies wird in GetKeySequenceWasPlayed gespeichert
            StartCoroutine(PlayGetKeySequence());
            GetKeySequenceWasPlayed = true;
        }


     // Hier wird verwaltet wann die Dialogoptionen Prefabs Spawnen. Hierfür werden mehrere DialogStates

        //in den Ersten Drei Phasen des Dialogs sind jeweils 2 Dialogoptionen verfügbar der spieler kann eine auswählen und schreitete dann zur nächsten phase weiter 
        if (DialogState == 1 && DOPrefabsareSpawned == false)
        {
            // Prefabs werden gespawned 
            GameObject DO1 = Instantiate(DOWarumKannstDuReden, DOParent) as GameObject;
            GameObject DO2 = Instantiate(DODasMussEinTraumSein, DOParent) as GameObject;
            DOPrefabsareSpawned = true;
        }
        
        if (DialogState == 2 && DOPrefabsareSpawned == false)
        {
            // Prefabs werden gespawned 
            GameObject DO1 = Instantiate(DODannRedeIchJetztMitEinerKatze, DOParent) as GameObject;
            GameObject DO2 = Instantiate(DODasIstVerrücktIchMussAufwachen, DOParent) as GameObject;
            DOPrefabsareSpawned = true;
        }
        
        if (DialogState == 3 && DOPrefabsareSpawned == false)
        {        
            // Prefabs werden gespawned 
            GameObject DO1 = Instantiate(DOWOIstEmma, DOParent) as GameObject;
            GameObject DO2 = Instantiate(DOWieBinIchHierhergekommen, DOParent) as GameObject;
            DOPrefabsareSpawned = true;
        }


        // In Phase 4 sind 2 weitere Dialogoptionen verfügbar die jedoch nicht die Phaen voranschreiten lassen. Ein Leave Button wird ebenfalls hinzugefügt.
        // Zudem sind 4 Item Abhängige Dialogoptionen verfügbar. DOFragNachKoma lässt den DialogState weiter voranschreiten 
        if (DialogState == 4)
        {
        
            if (DOPrefabsareSpawned == false)
                {   
                    // Prefabs werden gespawned sind nur in DialogState 4 verfügbar
                    GameObject DO1 = Instantiate(DOBinIchTod, DOParent) as GameObject;
                    GameObject DO2 = Instantiate(DOUndWasJetzt, DOParent) as GameObject;
                    DOPrefabsareSpawned = true;
                }  

            if (InventarManager.Instance.Items.Contains(Patientenakte) && DOFragNachKomaIsSpawned == false)
            //DO Prefab wird nur gespawned wenn sie nicht bereits Selectiert wurde + in diesem dialogState noch nicht gespawned ist 
                {
                    // wenn der Spieler das Item Patientenakte im Inventar hat wird die FragNachKoma DO gespawned 
                    GameObject DO5 = Instantiate(DOFragNachKoma, DOParent) as GameObject;
                    DOFragNachKomaIsSpawned = true;
                }

            if (InventarManager.Instance.Items.Contains(BriefanMama) && DOFragNachEmmasBriefIsSpawned == false && DOFragNachEmmasBriefWasSelected == false)
            //DO Prefab wird nur gespawned wenn sie nicht bereits Selectiert wurde + in diesem dialogState noch nicht gespawned ist 
                {
                    // wenn der Spieler das Item BriefanMama im Inventar hat wird die FragNachEmmasBrief DO gespawed diese DO ist nur in state 4 verfügbar 
                    GameObject DO3 = Instantiate(DOFragNachEmmasBrief, DOParent) as GameObject;
                    DOFragNachEmmasBriefIsSpawned = true;
                }
                
                // leave Button wird eingeblendet
                LeaveButton.SetActive(true);

        }
        

        if(DialogState == 4 ||DialogState == 6)
        {
            // die Optionalen DOs FragNachEmmasTagebuch, FütterdieKatze sind sowohl in state4 als auch im finalen state6 verfügbar

            // DO Fütter die Katze ist nur verfügbar wenn DOFragNachEmmasTagebuch bereits gewählt wurde. 
         if (InventarManager.Instance.Items.Contains(Tunfischdose) && DOFütterDieKatzeIsSpawned == false && DOFragNachEmmasTagebuchWasSelected == true && DOFütterDieKatzeWasSelected == false)
            //DO Prefab wird nur gespawned wenn sie nicht bereits Selectiert wurde + in diesem dialogState noch nicht gespawned ist 

            {// wenn der Spieler das Item Thunfischdose im Inventar hat wird die FütterDieKatze DO gespawned 
                GameObject DO6 = Instantiate(DOFütterDieKatze, DOParent) as GameObject;
                DOFütterDieKatzeIsSpawned = true;
            }

         if (InventarManager.Instance.Items.Contains(EmmasTagebuch) && DOFragNachEmmasTagebuchIsSpawned == false & DOFragNachEmmasTagebuchWasSelected == false)
            //DO Prefab wird nur gespawned wenn sie nicht bereits Selectiert wurde + in diesem dialogState noch nicht gespawned ist 

            {// wenn der Spieler das Item EmmasTagebuch im Inventar hat wird die FragNachEmmasTagebuch DO gespawned 
                GameObject DO4 = Instantiate(DOFragNachEmmasTagebuch, DOParent) as GameObject;
                DOFragNachEmmasTagebuchIsSpawned = true;
            }
        }  
        
         
            
            
        
        // in Phase 5 wird der letzte dialog abgespielt bevor das Ende einleitbar ist. Sie beinhaltet 2 Dialogoptionen. Optionale Itembedingte Dialogoptionen sind hier Pausiert und erst in Phase 6 wieder Wählbar

        if (DialogState == 5 && DOPrefabsareSpawned == false)
        {
            // LeaveButton wird ausgeblendet
            LeaveButton.SetActive(false);
            // Prefabs werden gespawned 
            GameObject DO1 = Instantiate(DOIchWillEmmaNichtVerlieren, DOParent) as GameObject;
            GameObject DO2 = Instantiate(DOIchWäreMeinLebenLangEineLast, DOParent) as GameObject;
            DOPrefabsareSpawned = true;
        }

        // finaler Dialog State hier sind nurnoch Optionale Itembedinge Dialogoptionen verfügbar
        if (DialogState == 6)
        {
            // leaveButton wird eingeblendet
            LeaveButton.SetActive(true);
            
            // Wenn Alle DialogStates Abgeschlossen sind und keine Itembedingten DOs mehr verfügbar sind wird die interaktionsmöglichkeit mit der Katze Deaktiviert.
            if (DOFragNachEmmasTagebuchWasSelected == true && DOFütterDieKatzeWasSelected == true)
            {
                AlldialogisFinished = true;
            }
        }
    }

// Diese Methode erhöht den DialogState um jeweils 1 

    private void NextDialogState()
    {
        // alle gespawnten Prefabs werden entfernt 
         foreach (Transform child in DOParent)
        {
            Destroy(child.gameObject);
        }
         // Spawn indikator variablen werden auf false gesetzt, Prefabs können jetzt erneut spawnen 
        DOPrefabsareSpawned = false;
        DOFragNachEmmasBriefIsSpawned = false;
        DOFragNachEmmasTagebuchIsSpawned = false;
        DOFütterDieKatzeIsSpawned = false;

        // DialogState wir um 1 erhöht
        DialogState = DialogState +1;
    }

   

    // Wenn DOFütterDieKatze selectiert wird, wird eine Reihe von Animationen und dialogen Abgespielt in welcher der Spieler das SchlüsselItem erhält
    private IEnumerator PlayGetKeySequence()
    {
        //Audio wird abgespielt
        DialogAudioController.Instance.PlayDialogueOption(5);
        //warten für dauer des AudioClips
        yield return new WaitForSeconds(7f);
        //VaseAnimation wird gestarted 
        KatzeAnimationsController.Instance.SetState(2);
        // dialogsystem wird geschlossen 
        HUDControlls.Instance.closeDialogsystem();


        yield return new WaitForSeconds(5f);
        // nach ende der Vase Animation wird dialogsystem wieder nutzbar gemacht
        DialogsystemIsUsabale = true;
        DialogSystemUI.SetActive(true);

    }

    // ermöglicht nach anwählen einer der Dialogoptionen in DialogState = 5 das einleiten der Enden 
    private IEnumerator InitialiseEndingChoice(float seconds)
    {
        // warte für dauer der gewählten dialogoption 
        yield return new WaitForSeconds(seconds);
        // einleiten der Enden wird ermöglicht 
        GameManager.Instance.InitialiseEndingChoices();

        // Dialogsystem wird geschlossen
        HUDControlls.Instance.closeDialogsystem();
    }


//Dialogoptionen der ersten Phase: 

   public void SelectDOWarumKannstDuReden()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(4);
        // nächste DialogState eingeleitet 
        NextDialogState(); 

    }

   public void SelectDODasMussEinTraumSein()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(7);
        // nächste DialogState eingeleitet 
        NextDialogState();    
    }

//Dialogoptionen der zweiten Phase: 

   public void SelectDODannRedeIchWohlMitEinerKatze()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(8);        
        //Katze Hält Marcell für schlau
        varianteSD = true;
        // nächste DialogState eingeleitet 
        NextDialogState();    
    }

   public void SelectDODasIstVerrücktIchMussAufwachen()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(9); 
        //Katze Hält Marcell für dumm
        varianteSD = false;
        // nächste DialogState eingeleitet 
        NextDialogState();    
    }

//Dialogoptionen der Dritten Phase:

   public void SelectDOWoistEmma()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(10);
        // nächste DialogState eingeleitet 
        NextDialogState();    
    }

   public void SelectDOWieBinIchHierhergekommen()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(11);
        // nächste DialogState eingeleitet 
        NextDialogState();    
    }
    
//Dialogoptionen der Vierten Phase:

   public void SelectDOBinIchTod()
    {
        // je nachdem ob die Katze den Spieler Für Dumm/Schlau Hält wird ein anderer Dialog abgespielt
        if(varianteSD == true)
        {
            //Audio wird abgespielt 
            DialogAudioController.Instance.PlayDialogueOption(13); 
        }else if (varianteSD == false)
        {
            //Audio wird abgespielt 
            DialogAudioController.Instance.PlayDialogueOption(12); 
        }
        
    }

    public void SelectDOUndWasJetzt()
    {   // je nachdem ob die Katze den Spieler Für Dumm/Schlau Hält wird ein anderer Dialog abgespielt
        if (varianteSD == true)
        {
            //Audio wird abgespielt 
            DialogAudioController.Instance.PlayDialogueOption(14); 
        }else if (varianteSD == false)
        {
            //Audio wird abgespielt 
            DialogAudioController.Instance.PlayDialogueOption(15); 
        }
    }

     public void SelectDOFragNachEmmasTagebuch()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(17); 

        //Katze bittet um Essen wenn der Spieler die Tunfischdose hat kann er sie nun der Katze geben.
        DOFragNachEmmasTagebuchWasSelected = true;
    }

    public void SelectDOFütterDieKatze()
    {
        Thunfischdose.SetActive(true);

        DialogsystemIsUsabale = false;
        DialogSystemUI.SetActive(false);

        KatzeAnimationsController.Instance.SetState(3);

        //Nachdem die FütterAnimation in BaseState3 Abgeschlossen wird bool EatingAnimationIsfinished im Animator = true gesetzt und somit automatisch in Update() die weiterführenden Dialoge und Animationen Abgespielt.

        DOFütterDieKatzeWasSelected = true;
    }

    public void SelectDOFragNachEmmasBrief()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(16); 
        DOFragNachEmmasBriefWasSelected = true;
    }

    public void SelectDOFragNachKoma()
    {
        //Audio wird abgespielt 
        DialogAudioController.Instance.PlayDialogueOption(18);
        // nächste DialogState eingeleitet 
        NextDialogState();
    }

    public void SelectDOIchWäreMeinLebenLangEineLast()
    {
        // Itemanzahl wird festgestellt
        int ItemNumber = InventarManager.Instance.Items.Count;

        // Alle items wurden eingesammelt. 
        if (ItemNumber == 8 && DOFütterDieKatzeWasSelected == true)
        {

            // je nachdem ob die Katze den Spieler Für Dumm/Schlau Hält wird ein anderer Dialog abgespielt
            if (varianteSD == true)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(21);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(64));
            }
            else if (varianteSD == false)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(22);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(56));
            }
        }

        // wenn noch nicht alle Items eingesammelt wurden, wird der spieler in einem leicht anderen Dialog daran errinert sich nocheinmal umzusehen 
        else if (ItemNumber <= 7 || DOFütterDieKatzeWasSelected == false)
        {
            // je nachdem ob die Katze den Spieler Für Dumm/Schlau Hält wird ein anderer Dialog abgespielt
            if (varianteSD == true)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(19);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(72));
            }
            else if (varianteSD == false)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(20);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(64));
            }

            // nachdem eine Option gewählt wurde wird der nächste DialogState eingeleitet 
        }
        NextDialogState();

    }


    public void SelectDOIchWillEmmaNichtVerlieren()
        {
        // Itemanzahl wird festgestellt
        int ItemNumber = InventarManager.Instance.Items.Count;

        // alle Items wurden eingesammelt
        if (ItemNumber == 8 && DOFütterDieKatzeWasSelected == true)
        {
            // je nachdem ob die Katze den Spieler Für Dumm/Schlau Hält wird ein anderer Dialog abgespielt
            if (varianteSD == true)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(25);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(60));
            }
            else if (varianteSD == false)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(26);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(53));
            }
        }

        // wenn noch nicht alle Items eingesammelt wurden, wird der spieler in einem leicht anderen Dialog daran errinert sich nocheinmal umzusehen 
        else if (ItemNumber <= 7 || DOFütterDieKatzeWasSelected == false)
        {
            // je nachdem ob die Katze den Spieler Für Dumm/Schlau Hält wird ein anderer Dialog abgespielt
            if (varianteSD == true)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(23);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(68));
            }
            else if (varianteSD == false)
            {
                //Audio wird abgespielt 
                DialogAudioController.Instance.PlayDialogueOption(24);

                //ending Animation wird nach ablauf des dialoges eingeleitet 
                StartCoroutine(InitialiseEndingChoice(61));
            }
        }

            // nachdem eine Option gewählt wurde wird der nächste DialogState eingeleitet 
            NextDialogState();
    }
}
