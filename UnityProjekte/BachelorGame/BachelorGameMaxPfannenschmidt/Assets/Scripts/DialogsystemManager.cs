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

    // Items welche mit Dialogsystem Interagieren
    public Item EmmasTagebuch;
    public Item BriefanMama;
    public Item Patientenakte;
    public Item Tunfischdose;
    
    // Start is called before the first frame update
    
    
        private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DialogState = 1;
        DOPrefabsareSpawned = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //in den Ersten Drei Phasen des DIalogs sind jeweils 2 Dialogoptionen verfügbar
        if(DialogState == 1 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DOWarumKannstDuReden, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DODasMussEinTraumSein, DOParent) as GameObject;
        DOPrefabsareSpawned = true;
        }
        else if (DialogState == 2 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DODannRedeIchJetztMitEinerKatze, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DODasIstVerrücktIchMussAufwachen, DOParent) as GameObject;
        DOPrefabsareSpawned = true;

        }
        else if (DialogState == 3 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DOWOIstEmma, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DOWieBinIchHierhergekommen, DOParent) as GameObject;
        DOPrefabsareSpawned = true;

        }
        else if (DialogState == 4 && DOPrefabsareSpawned == false)
        {
        GameObject DO1 = Instantiate(DOBinIchTod, DOParent) as GameObject;
        GameObject DO2 = Instantiate(DOUndWasJetzt, DOParent) as GameObject;
        
          /*  if (InventarManager.Instance.Items.Contains(BriefanMama))
                {
                GameObject DO3 = Instantiate(DOFragNachEmmasBrief, DOParent) as GameObject;
                }
            
            if (InventarManager.Instance.Items.Contains(EmmastagebuchGeschlossen))
                {
                GameObject DO4 = Instantiate(DOFragNachEmmasTagebuch, DOParent) as GameObject;
                }
            
            if (InventarManager.Instance.Items.Contains(Patientenakte))
                {
                GameObject DO5 = Instantiate(DOFragNachKoma, DOParent) as GameObject;
                }
            
            if (InventarManager.Instance.Items.Contains(Tunfischdose))
                {
                GameObject DO6 = Instantiate(DOFütterDieKatze, DOParent) as GameObject;
                }*/
        
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
        DialogState = DialogState +1;

    }

//Dialogoptionen der ersten Phase: 
    public void SelectDOWarumKannstDuReden()
    {
        //Audio is Played in another Script
        NextDialogState();    
        }

   public void SelectDODasMussEinTraumSein()
    {
        //Audio is Played in another Script
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
    }
     public void SelectDOFütterDieKatze()
    {
        //AudioIstPlayed
    }
    public void SelectDOFragNachEmmasBrief()
    {
        //AudioIstPlayed
    }
     public void SelectDOFragNachKoma()
    {
        //AudioIstPlayed
    }
     public void SelectDOIchWäreMeinLebenLangEineLast()
    {
        //AudioIstPlayed
    }
     public void SelectDOIchWillEmmaNichtVerlieren()
    {
        //AudioIstPlayed
    }


}
