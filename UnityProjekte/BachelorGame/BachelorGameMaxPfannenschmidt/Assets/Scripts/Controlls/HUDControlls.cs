using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControlls : MonoBehaviour
{// Dieses Script verwaltet die Zustände der Verschiedenen Menüs im Spiel wie Inventar oder Dialogsystem
    public static HUDControlls Instance;

    // variable bestimmt ob Inventar nutzbar ist
    public bool Inventroryisuseabale;

    // bestimmt ob Inventar geöffnet ist 
    public bool InventoryisOpen;

    // bestimmt ob Spiel pausiert ist
    private bool gameisPaused;

    // bestimmt ob Dialogsystem geöffnet ist
    public bool DialogsystemisOpen;
    
    // UI elemente für das Inventar
    public GameObject ItemUI;
    // UI elemente für das Freie Spielen (Kein Menü ist geöffnet)
    public GameObject GameUI;
    // UI elemente für das Pause Menü
    public GameObject PauseUI;
    // UI elemente für das Dialogsystem
    public GameObject DialogSystemUI;

    // bestimmt ob Steuerungsanleitung im PauseMenü sichtbar ist 
    private bool SteuerungIsVisible;
    // UI der Steuerungsanleitung
    public GameObject SteuerungUI;
    // volume Controller referenz 
    public GameObject volumeController;
    // AudioSource für die UI soundeffekte 
    public AudioSource source;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spiel läuft normal (nicht pausiert)
        Time.timeScale = 1;

        // kein Menü ist geöffnet 
        gameisPaused = false;
        InventoryisOpen = false;
        Inventroryisuseabale = false;   
    }

    // Update is called once per frame
    void Update()
    {
        // wenn i Gedrückt wird wird das inventar geöffnet/ geschlossen
        if (Input.GetKeyDown("i") && Inventroryisuseabale == true)
        {
            if (InventoryisOpen == false)
            {
                openInventory();
            } 
            else if  (InventoryisOpen == true)
            {
                closeInventory();
            }
        }

        //wenn das dialogsystem Aktiv ist kann das spiel nicht pausiert werden 
        if (DialogsystemisOpen == false)
            {
             //mit Escape kann das Pause menu geöffnet und geschlossen werden 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameisPaused == false)
                {
                    PauseGame();
                } 
            else if  (gameisPaused == true)
                {
                    ResumeGame();
                }
        }
    }
    }

    // funktion um das Inventar zu Schließen
    public void closeInventory()
    {
        // variable gibt an das Inventar geschlossen ist 
        InventoryisOpen = false;

        //das korrekte UI wird eingeblendet
        ItemUI.SetActive(false);
        GameUI.SetActive(true);

        // im script FPSController wird die bewegung freigegeben
        FPSController fps = gameObject.GetComponent<FPSController>();
        fps.unlockMovement();

        // der volumeController ändert die focal lenght so dass der Hintergrund Scharf/unscharf wird.
        BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.StartFadeOut(); 
    }
    
    // funktion um das Inventar zu öffnen 
    public void openInventory()
    {   
        // sound wird abgespielt
        source.Play();

        // variable gibt an das Inventar geschlossen ist 
        InventoryisOpen = true;

        //das korrekte UI wird eingeblendet
        ItemUI.SetActive(true);
        GameUI.SetActive(false);
        
        // im script FPSController wird die bewegung eingefroren
        FPSController fps = gameObject.GetComponent<FPSController>();
        fps.lockMovement();
        
        // der volumeController ändert die focal lenght so dass der Hintergrund Scharf/unscharf wird.
        BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.StartFadeIn(); 
    }

    public void openDialogsystem()
    {
    //inventar ist nicht mehr nutzbar
    Inventroryisuseabale = false;
    
    //das korrekte UI wird eingeblendet
    GameUI.SetActive(false);
    DialogSystemUI.SetActive(true);
    
    // im script FPSController wird die bewegung eingefroren
    FPSController fps = gameObject.GetComponent<FPSController>();
    fps.lockMovement();

    //variable gibt an das Dialotsystem Geöffnet ist.
    DialogsystemisOpen = true;
    }

    // funktion um das Dialogsystem zu schließen 
    public void closeDialogsystem()
    {
    //inventar ist wieder nutzbar
    Inventroryisuseabale = true;

    //das korrekte UI wird eingeblendet
    GameUI.SetActive(true);
    DialogSystemUI.SetActive(false);

    // im script FPSController wird die bewegung freigegeben
    FPSController fps = gameObject.GetComponent<FPSController>();
    fps.unlockMovement();

    DialogsystemisOpen = false;
    }

    // Funktion um das Spiel zu pausieren 
    public void PauseGame()
    {
    //Spiel wird pausiert
    Time.timeScale = 0;
    gameisPaused = true;

    // wenn das inventar geöffnet ist wird es geschlossen
    if (InventoryisOpen == true)
    {
        closeInventory();
    }
    
    // bewegung eingefroren 
    FPSController fps = gameObject.GetComponent<FPSController>();
    fps.lockMovement();
    
    // UI wird ausgewählt
    ItemUI.SetActive(false);
    GameUI.SetActive(false);
    PauseUI.SetActive(true);


    // inventar nicht mehr nutzbar 
    Inventroryisuseabale = false;
    }

    // funktion um das Spiel fortzusetzten 
    public void ResumeGame()
    {
    // Spiel läuft weiter
    Time.timeScale = 1;
    gameisPaused = false;

    //UI wird aktiviert
    PauseUI.SetActive(false);
    GameUI.SetActive(true);

     // wenn die Steuerung sichbar ist wird sie beim resumen wieder Abgeschaltet 
     if (SteuerungIsVisible == true)
    {
        SteuerungButton();
    }

    //Inventar ist wieder nutzbar 
    Inventroryisuseabale = true;

    // bewegung wird freigegeben 
    FPSController fps = gameObject.GetComponent<FPSController>();
    fps.unlockMovement();
    }


    

// script welches mit dem SteuerungsButton im Menu verknüpft wird. es blendet die Steuerung ein und Aus 
    public void SteuerungButton()
    {
        if(SteuerungIsVisible == true)
        {
            SteuerungUI.SetActive(false);
            SteuerungIsVisible = false;
        }
        else if (SteuerungIsVisible == false)
        {
            SteuerungUI.SetActive(true);
            SteuerungIsVisible = true;
        }
    }


    public void SetGameState()
    {// diese Funktion dient dazu nach ablauf der Start Sequenz den GameState einzuleiten
        GameUI.SetActive(true);
        Inventroryisuseabale = true;
        // Im GameManager wird die variable interactionEnabled auf true gesetzt was die Interaktion mit obejekten ermöglicht.
        GameManager.Instance.InteractionEnabled = true;

    }
}
