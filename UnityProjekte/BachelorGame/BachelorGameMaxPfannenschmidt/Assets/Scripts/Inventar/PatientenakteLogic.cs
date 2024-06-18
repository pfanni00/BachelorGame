using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientenakteLogic : MonoBehaviour
{
    // Dieses Script verwaltet den Einsammel Prozess der Patientenakte. Sammelt der Spiele beide ZerissenerZettel Items bekommt er die Patientenakte
    public static PatientenakteLogic Instance;
    // Item daten für ZerissenerZettel und Patientenakte
    public Item ZerissenerZettel;
    public Item Patientenakte;

    // verknüpfung zum Player 
    public GameObject Player;

    // aktueller status der Patientenakte
    private int patientenakteState;

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        // zum Start hat der Spieler noch keines der Items im inventar der State ist somit 0 und beide Items sind auf isNew = true gesetzt, so dass sie beim einsammeln vom InventarManager selectiert werden. 
        patientenakteState = 0;
        ZerissenerZettel.isNew = true;
        Patientenakte.isNew = true;
    }

    // diese Funktion wird beim einsammeln eines ZerissenerZettel Items durch PatientenaktiePickup
    public void PatientenakteStates()
    {
        patientenakteState = patientenakteState + 1;
        if (patientenakteState == 1)
        { // hat der einen Zerissenen Zettel gefunden wird dieser als Item Hinzugefügt und das Inventar geöffnet
            InventarManager.Instance.Add(ZerissenerZettel);
            HUDControlls.Instance.openInventory();

        }
        else if (patientenakteState == 2)
        {// hat der Spieler zwei Zerissene Zettel gefunden wird das ZerissenerZettel item aus dem Inventar entfernt und die Patientenakte hinzugefügt. Das Inventar wird geöffnet 
            HUDControlls.Instance.openInventory();
            InventarManager.Instance.Remove(ZerissenerZettel);
            InventarManager.Instance.Add(Patientenakte);
        }
    }
}
