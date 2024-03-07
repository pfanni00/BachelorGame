using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadButton : MonoBehaviour
{
    public bool IsVisible;
   // public GameObject TextObject; 
    private Image image;

    // Start is called before the first frame update
    void Start()
    {  // image = TextObject.GetComponent<Image>();
        IsVisible = false;
    }

   void update ()
   {
    if (IsVisible == false)
    {
       image.enabled = false;
    }else if (IsVisible == true)
    {
        image.enabled = true;
    }
   }

   public void ClickReadButton()
   {
    IsVisible = !IsVisible;
   }
}
