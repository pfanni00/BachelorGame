using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientenaktieLogic : MonoBehaviour
{
    // Dieses Script bestimmt welches Item je nach anzahl der aufgehobenen Zerissenen Zettel dem InventarManager hinzugefügt werden. 
    public Item ZerissenerZettel;
    public Item Patientenaktie;

    public GameObject Player;
    private int patientenaktieState;

void Start()
{
    patientenaktieState = 0;
}
    public void PatientenaktieStates()
        {
            patientenaktieState = patientenaktieState +1;
            if (patientenaktieState == 1)
            {
                InventarManager.Instance.Add(ZerissenerZettel);
                HUDControlls ic = Player.GetComponent<HUDControlls>();
                ic.openInventory();    

            }else if (patientenaktieState == 2)
            {
                HUDControlls ic = Player.GetComponent<HUDControlls>();
                ic.openInventory();  
                InventarManager.Instance.Remove(ZerissenerZettel);
                InventarManager.Instance.Add(Patientenaktie);
            }
        }
}
