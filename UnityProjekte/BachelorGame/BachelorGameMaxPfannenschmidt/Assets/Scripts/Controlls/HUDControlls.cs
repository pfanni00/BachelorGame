using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControlls : MonoBehaviour
{// Dieses Script verwaltet die Zustände der Verschiedenen Menüs im Spiel wie Inventar oder Dialogsystem
    public bool Inventroryisuseabale;
    public bool InventoryisOpen;

    public bool DialogsystemisOpen;
    public GameObject ItemUI;
    public GameObject GameUI;
    
    public GameObject DialogSystemUI;
    public GameObject volumeController;



    // Start is called before the first frame update
    void Start()
    {
        Inventroryisuseabale = true;
        closeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i") && Inventroryisuseabale == true)
        {
         Debug.Log("INVENTAR");
            if (InventoryisOpen == false)
            {
                openInventory();
            } 
            else if  (InventoryisOpen == true)
            {
                closeInventory();
            }
        }
    }
    public void closeInventory()
    {
        InventoryisOpen = false;
        ItemUI.SetActive(false);
        GameUI.SetActive(true);
        FPSController fps = gameObject.GetComponent<FPSController>();
        fps.unlockMovement();
        BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.StartFadeOut(); 
    }
    
    public void openInventory()
    {
        InventoryisOpen = true;
        ItemUI.SetActive(true);
        GameUI.SetActive(false);
        FPSController fps = gameObject.GetComponent<FPSController>();
        fps.lockMovement();
        BackgroundBlur bg = volumeController.GetComponent<BackgroundBlur>();
        bg.StartFadeIn(); 
    }

    public void openDialogsystem()
    {
    Inventroryisuseabale = false;
    GameUI.SetActive(false);
    DialogSystemUI.SetActive(true);
    FPSController fps = gameObject.GetComponent<FPSController>();
    fps.lockMovement();
    }

    public void closeDialogsystem()
    {
    Inventroryisuseabale = true;
    GameUI.SetActive(true);
    DialogSystemUI.SetActive(false);
    FPSController fps = gameObject.GetComponent<FPSController>();
    fps.unlockMovement();
    }
}
