using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsystemManager : MonoBehaviour
{
    public static DialogsystemManager Instance;

    public bool DialogsystemIsUsabale;
    public int DialogState;
    public bool AlldialogisFinished;
    private bool GetKeySequenceWasPlayed;

    // Controlliert ob variante Schlau oder Dumm aktiv ist.
    private bool varianteSD;
    
    private bool DOPrefabsareSpawned;
    public GameObject DialogSystemUI;
    public Transform DOParent;
    public GameObject Katze;
    public GameObject Player;


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
        GetKeySequenceWasPlayed = false;
        DialogsystemIsUsabale = true;

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
        if (katzeanimator.GetBool("AimisActive") == false)
        {
            DialogSystemUI.SetActive(false);
        }else if(katzeanimator.GetBool("AimisActive") == true)
        {
            DialogSystemUI.SetActive(true);
        }
    
       

        // Ist das Dialogsystem nicht nutzbar wird das HUD ausgeblendet Außerdem ist die Interaktion mit der Katze nicht mehr möglich 
        if (DialogsystemIsUsabale == false)
        {
            //DialogSystemUI.SetActive(false);
        }
        else if (DialogsystemIsUsabale == true)
        {
            //DialogSystemUI.SetActive(true);
        }

        // wenn Dialog Gespielt wird wird das UI Ausgeblendet
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
            StartCoroutine(PlayGetKeySequence());
            GetKeySequenceWasPlayed = true;
        }


        //in den Ersten Drei Phasen des Dialogs sind jeweils 2 Dialogoptionen verfügbar
        if (DialogState == 1 && DOPrefabsareSpawned == false)
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

            if (InventarManager.Instance.Items.Contains(BriefanMama) && DOFragNachEmmasBriefIsSpawned == false && DOFragNachEmmasBriefWasSelected == false)
                {
                GameObject DO3 = Instantiate(DOFragNachEmmasBrief, DOParent) as GameObject;
                DOFragNachEmmasBriefIsSpawned = true;
                }
                        LeaveButton.SetActive(true);

        }
        

        if(DialogState == 4 ||DialogState == 6)
        {
         if (InventarManager.Instance.Items.Contains(Tunfischdose) && DOFütterDieKatzeIsSpawned == false && DOFragNachEmmasTagebuchWasSelected == true && DOFütterDieKatzeWasSelected == false)
                {
                GameObject DO6 = Instantiate(DOFütterDieKatze, DOParent) as GameObject;
                DOFütterDieKatzeIsSpawned = true;
                }

         if (InventarManager.Instance.Items.Contains(EmmasTagebuch) && DOFragNachEmmasTagebuchIsSpawned == false & DOFragNachEmmasTagebuchWasSelected == false)
                {
                GameObject DO4 = Instantiate(DOFragNachEmmasTagebuch, DOParent) as GameObject;
                DOFragNachEmmasTagebuchIsSpawned = true;
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
            LeaveButton.SetActive(true);

            if (DOFragNachEmmasTagebuchWasSelected == true && DOFütterDieKatzeWasSelected == true)
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

    // Wenn der Spieler die Katze füttert wird eine Reihe von Animationen und dialogen Abgespielt in welcher er den Schlüssel erhält
    private IEnumerator PlayGetKeySequence()
    {
        
        DialogAudioController.Instance.PlayDialogueOption(5);
        
        yield return new WaitForSeconds(7f);

        KatzeAnimationsController.Instance.SetState(2);
        HUDControlls.Instance.closeDialogsystem();


        yield return new WaitForSeconds(5f);

        DialogsystemIsUsabale = true;
        DialogSystemUI.SetActive(true);

    }

    private IEnumerator InitialiseEndingChoice(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.InitialiseEndingChoices();
        HUDControlls.Instance.closeDialogsystem();
    }


    //Dialogoptionen der ersten Phase: 
    public void SelectDOWarumKannstDuReden()
    {
        DialogAudioController.Instance.PlayDialogueOption(4);
        NextDialogState(); 

    }

   public void SelectDODasMussEinTraumSein()
    {
        DialogAudioController.Instance.PlayDialogueOption(7);
        NextDialogState();    
    }

    //Dialogoptionen der zweiten Phase: 
   public void SelectDODannRedeIchWohlMitEinerKatze()
    {
        DialogAudioController.Instance.PlayDialogueOption(8);        
        //Katze Hält Marcell für schlau
        varianteSD = true;
        NextDialogState();    
    }

   public void SelectDODasIstVerrücktIchMussAufwachen()
    {
        DialogAudioController.Instance.PlayDialogueOption(9); 
        //Katze Hält Marcell für dumm
        varianteSD = false;
        NextDialogState();    
    }

//Dialogoptionen der Dritten Phase:

   public void SelectDOWoistEmma()
    {
        DialogAudioController.Instance.PlayDialogueOption(10); 
        
        NextDialogState();    
    }

   public void SelectDOWieBinIchHierhergekommen()
    {
        DialogAudioController.Instance.PlayDialogueOption(11); 
        NextDialogState();    
    }
    
//Dialogoptionen der Vierten Phase:

   public void SelectDOBinIchTod()
    {
        if(varianteSD == true)
        {
        DialogAudioController.Instance.PlayDialogueOption(13); 
        }else if (varianteSD == false)
        {
        DialogAudioController.Instance.PlayDialogueOption(12); 
        }
        
    }

    public void SelectDOUndWasJetzt()
    {
         if(varianteSD == true)
        {
        DialogAudioController.Instance.PlayDialogueOption(14); 
        }else if (varianteSD == false)
        {
        DialogAudioController.Instance.PlayDialogueOption(15); 
        }
    }

     public void SelectDOFragNachEmmasTagebuch()
    {
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
        DialogAudioController.Instance.PlayDialogueOption(16); 
        DOFragNachEmmasBriefWasSelected = true;
    }
     public void SelectDOFragNachKoma()
    {
        DialogAudioController.Instance.PlayDialogueOption(18); 
        NextDialogState();
    }
     public void SelectDOIchWäreMeinLebenLangEineLast()
    {
        int ItemNumber = InventarManager.Instance.Items.Count;

        if (ItemNumber == 8 && DOFütterDieKatzeWasSelected == true)
        {
            if(varianteSD == true)
            {
            // Alle Items Wurden eingesammelt und Variante Schlau ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(21);
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(64)); 
            }
            else if(varianteSD == false)
            {
            // Alle Items Wurden eingesammelt und Variante Dumm ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(22); 
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(56)); 
            }
        }
        else if(ItemNumber <= 7 || DOFütterDieKatzeWasSelected == false)
            if(varianteSD == true)
            {
            // Es wurden noch nicht alle Items eingesammelt und Variante Schlau ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(19);
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(72));  
            }
            else if(varianteSD == false)
            {
            // Alle Items Wurden eingesammelt und Variante Dumm ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(20); 
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(64)); 
            }
            NextDialogState();
    }
     public void SelectDOIchWillEmmaNichtVerlieren()
    {
        int ItemNumber = InventarManager.Instance.Items.Count;

        if (ItemNumber == 8 && DOFütterDieKatzeWasSelected == true)
        {
            if(varianteSD == true)
            {
            // Alle Items Wurden eingesammelt und Variante Schlau ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(25);
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(60)); 
            }
            else if(varianteSD == false)
            {
            // Alle Items Wurden eingesammelt und Variante Dumm ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(26); 
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(53)); 
            }
        }
        else if(ItemNumber <= 7 || DOFütterDieKatzeWasSelected == false)
            if(varianteSD == true)
            {
            // Es wurden noch nicht alle Items eingesammelt und Variante Schlau ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(23);
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(68));  
            }
            else if(varianteSD == false)
            {
            // Alle Items Wurden eingesammelt und Variante Dumm ist aktiv 
            DialogAudioController.Instance.PlayDialogueOption(24); 
            //ending Animation wird nach länge des dialoges eingeleitet 
            StartCoroutine(InitialiseEndingChoice(61)); 
            }

            NextDialogState();

    }


}
