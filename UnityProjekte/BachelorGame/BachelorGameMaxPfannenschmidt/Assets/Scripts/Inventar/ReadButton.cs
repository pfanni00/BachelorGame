using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadButton : MonoBehaviour
{
    // Dieses Script kümmert sich um die Funktion der ReadButtons (außer bei Emmas Tagebuch)
    // boolean bestimmt sichtbarkeit des Textes
    public bool IsVisible;
    // einzublendender Text als GameObject
    public GameObject textobject;

    // Start is called before the first frame update
    void Start()
    {
        // Texte sind zum Start des Spiels ausgeblendet.
        IsVisible = false;
    }

  
    // diese funktion wird mit dem ReadButton verknüpft.
   public void ClickReadButton()
   {
       // Textwird ein/ausgeblendet 
    IsVisible = !IsVisible;
    if (IsVisible == false)
    {
       textobject.SetActive(false);
    }else if (IsVisible == true)
    {
       textobject.SetActive(true);
    }   
    }
}
