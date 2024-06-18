using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    // Arrays mit allen UI GameObjecten die beim selectieren eines Ítems ein/aus geblendet werden sollen. 
    public GameObject[] UITabletten;
    public GameObject[] UIEmmasTagebuchGeschlossen;
    public GameObject[] UIEmmasTagebuchGeöffnet;
    public GameObject[] UIZerissenerZettel;
    public GameObject[] UIPatientenaktie;
    public GameObject[] UIBriefanMama;
    public GameObject[] UILiebesbrief;
    public GameObject[] UITunfischdose;
    public GameObject[] UIKühlschrankmagnet;
    public GameObject[] UIKarte;


    // Die Funktion Select item wird über InventoryToggle oder InventarManager aufgerufen. Sie ruft anhand des eingegebenen tag eine Funktion auf die das Korrekte UI einblendet. 
    
       public void SelectItem(string tag)
{
           if (tag == "ItemTabletten")
                {
                SelectTabletten();
                }
          
            else if(tag =="BriefanMama")
                {
                SelectBriefanMama();  
                }
            else if(tag =="EmmasTagebuchGeöffnet")
                {
                SelectEmmasTagebuchGeöffnet();
                }
            else if(tag =="EmmasTagebuchGeschlossen")
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
            else if (tag=="Tunfischdose")
                {
                SelectTunfischdose();    
                }
            else if (tag=="Liebesbrief")
                {
                SelectLiebesbrief();
                }
            else if (tag== "Kühlschrankmagnet")
                {
                SelectKühlschrankmagnet();
                }
           else if (tag == "Karte")
                {
                SelectKarte();
                }
}
    //Jedes Item hat eine eingene Select[ItemName] Funktion. Diese Blenden die jeweiligen elemente des eingegebenen tag ein und Alle anderen UI elemente Aus. 
    public void SelectTabletten()
    {    
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
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
         foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
            uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
        }
        foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(true);
        }
        
    }

   
    public void SelectBriefanMama()
    {
       foreach (GameObject uitabletten in UITabletten)
        {
            uitabletten.SetActive(false);
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
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
         foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
            uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
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
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
         foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
            uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
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
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
         foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
        uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
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
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
        foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
        uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
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
         foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
        foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
        uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
        }
        foreach (GameObject uipatientenaktie in UIPatientenaktie)
        {
            uipatientenaktie.SetActive(true);
        }
    }

    public void SelectTunfischdose()
    {
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
        foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
        uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
        }
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(true);
        }
    }
        public void SelectLiebesbrief()
        {
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
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
        uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
        }
        foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(true);
        }
        }

        public void SelectKühlschrankmagnet()
            {
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
        foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
        uiTunfischdose.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
        uiKühlschrankmagnet.SetActive(true);
        }
    }

    public void SelectKarte()
    {
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
        foreach (GameObject uiLiebesbrief in UILiebesbrief)
        {
            uiLiebesbrief.SetActive(false);
        }
        foreach (GameObject uiTunfischdose in UITunfischdose)
        {
            uiTunfischdose.SetActive(false);
        }
        foreach (GameObject uiKühlschrankmagnet in UIKühlschrankmagnet)
        {
            uiKühlschrankmagnet.SetActive(false);
        }
        foreach (GameObject uiKarte in UIKarte)
        {
            uiKarte.SetActive(true);
        }
    }


}
