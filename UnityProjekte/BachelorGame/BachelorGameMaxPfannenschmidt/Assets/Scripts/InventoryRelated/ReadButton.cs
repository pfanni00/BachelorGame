using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadButton : MonoBehaviour
{
    public bool IsVisible;
   // public GameObject TextObject; 
    public GameObject textobject;

    // Start is called before the first frame update
    void Start()
    {  // image = TextObject.GetComponent<Image>();
        IsVisible = false;
    }

   void update ()
   {
    
   }

   public void ClickReadButton()
   {
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
