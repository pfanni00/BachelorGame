using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControlls : MonoBehaviour
{// Dieses Script verwaltet die Zustände der Verschiedenen Menüs im Spiel wie Inventar oder Dialogsystem
    public static HUDControlls Instance;


    public bool Inventroryisuseabale;
    public bool InventoryisOpen;
    private bool gameisPaused;
    public bool DialogsystemisOpen;
    public GameObject ItemUI;
    public GameObject GameUI;
    public GameObject PauseUI;
    private bool SteuerungIsVisible;
    public GameObject SteuerungUI;
    public GameObject DialogSystemUI;
    public GameObject volumeController;
    public AudioSource source;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
            Time.timeScale = 1;

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
                Debug.Log("Pause");
            } 
            else if  (gameisPaused == true)
            {
                ResumeGame();
            }
        }
    }
       
    }
    public void closeInventory()
    {
        //das korrekte UI wird eingeblendet
        InventoryisOpen = false;
        ItemUI.SetActive(false);
        GameUI.SetActive(true);
        // im script FPSController wird die bewegung freigegeben
        FPSController fps = gameObject.GetComponent<FPSController>();
        fps.unlockMovement();
        // der volumeController ändert die focal lenght so dass der Hintergrund Scharf/unscharf wird.
        BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.StartFadeOut(); 
    }
    
    public void openInventory()
    {   
        // sound wird abgespielt
        source.Play();
        //das korrekte UI wird eingeblendet
        InventoryisOpen = true;
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

    DialogsystemisOpen = true;
    }


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

    public void PauseGame()
    {
        //Spiel wird pausiert
    Time.timeScale = 0;
    gameisPaused = true;

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


    public void ResumeGame()
    {
        // Spiel läuft weiter
    Time.timeScale = 1;
    gameisPaused = false;

        //UI wird aktiviert
    PauseUI.SetActive(false);
    GameUI.SetActive(true);

     // wenn die Steuerung sichbar sit wird sie beim resumen wieder Abgeschaltet 
     if (SteuerungIsVisible == true)
    {
        SteuerungButton();
    }

    //Inventar ist wieder nutzbar 
    Inventroryisuseabale = true;

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
