using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientenaktieLogic : MonoBehaviour
{
    // Dieses Script bestimmt welches Item je nach anzahl der aufgehobenen Zerissenen Zettel dem InventarManager hinzugefügt werden. 
    public Item ZerissenerZettel;
    public Item Patientenaktie;

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
            }else if (patientenaktieState == 2)
            {
                 InventarManager.Instance.Remove(ZerissenerZettel);
                 InventarManager.Instance.Add(Patientenaktie);
            }
        }
}
