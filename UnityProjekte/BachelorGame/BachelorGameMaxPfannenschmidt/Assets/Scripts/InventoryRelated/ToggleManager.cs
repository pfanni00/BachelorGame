using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public GameObject[] UITabletten;
    public GameObject[] UIPostkarte;
    public GameObject[] UIEmmasTagebuchGeschlossen;
    public GameObject[] UIEmmasTagebuchGeöffnet;
    public GameObject[] UIZerissenerZettel;
    public GameObject[] UIPatientenaktie;
    public GameObject[] UIBriefanMama;
    // Start is called before the first frame update
    
       public void SelectItem(string tag)
{
           if (tag == "ItemTabletten")
            {
            SelectTabletten();
            
            }else if(tag =="ItemPostkarte")
            {
           SelectPostkarte(); 

            }else if(tag =="BriefanMama")
            {
           SelectBriefanMama();  
            
            }else if(tag =="EmmasTagebuchGeöffnet")
            {
           SelectEmmasTagebuchGeöffnet();
            
            }else if(tag =="EmmasTagebuchGeschlossen")
            {
            SelectEmmasTagebuchGeschlossen();  
           
            }
            else if(tag =="EmmasTagebuchGeöffnet")
            {
            SelectEmmasTagebuchGeöffnet(); 
           
            }
            else if (tag=="ZerissenerZettel")
            {
           SelectZerissenerZettel();   
           
            }
            else if (tag=="MeinePatientenaktie")
            {
           SelectPatientenaktie();
                
            }
}
   
    public void SelectTabletten()
    {
        Debug.Log("SelectTabletten");
        
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
        foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(false);
        }
        foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(false);
        }
        foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(true);
        }
        
    }

    public void SelectPostkarte()
    {
                Debug.Log("SelectPostkarte");

       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }

         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(false);
        }
         foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(false);
        }
                foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(true);
        }
    }

    public void SelectBriefanMama()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
                foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(false);
        }
                         foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(false);
        }
         foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(false);
        }
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(true);
        }
        
    }

public void SelectEmmasTagebuchGeöffnet()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
                 foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(false);
        }
         foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(true);
        }
    }

public void SelectEmmasTagebuchGeschlossen()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(false);
        }
         foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(false);
        }
         foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(true);
        }
    }

public void SelectZerissenerZettel()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(false);
        }
         foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(false);
        }
        foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(true);
        }
    }
public void SelectPatientenaktie()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
        }
        foreach (GameObject uipostkarte in UIPostkarte)
        {
            uipostkarte.SetActive(false);
        }
         foreach (GameObject uibriefanmama in UIBriefanMama)
        {
            uibriefanmama.SetActive(false);
        }
        foreach (GameObject uiemmastagebuchgeöffnet in UIEmmasTagebuchGeöffnet)
        {
            uiemmastagebuchgeöffnet.SetActive(false);
        }
         foreach (GameObject uiemmastagebuchgeschlossen in UIEmmasTagebuchGeschlossen)
        {
            uiemmastagebuchgeschlossen.SetActive(false);
        }
        foreach (GameObject uizerissenerzettel in UIZerissenerZettel)
        {
            uizerissenerzettel.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(true);
        }
    }
}
