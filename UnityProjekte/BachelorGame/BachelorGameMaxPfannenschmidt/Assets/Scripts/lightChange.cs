using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChange : MonoBehaviour
{
    public int trigger;
    public Texture2D[] StartLightMapDir, StartLightMapColor, StartLightMapShadowMask;
    public Texture2D[] EndingLightMapDir, EndingLightMapColor, EndingLightMapShadowMask;
    public Texture2D[] DarkLightMapDir, DarkLightMapColor, DarkLightMapShadowMask;

    public ReflectionProbe[] startReflectionProbes, endingReflectionProbes, darkReflectionProbes;
    public GameObject[] lightsStartObj;
    public GameObject[] lightsEndingObj;
    public GameObject[] lightsOutObj;



    private LightmapData[] startLightMap, endingLightMap, darkLightMap;

    // Start is called before the first frame update
    void Start()
    {
        trigger = 1;

        // Initialize Lightmaps
        List<LightmapData> Slightmap = new List<LightmapData>();
        for (int i = 0; i < StartLightMapDir.Length; i++)
        {
            LightmapData lmdata = new LightmapData();
            lmdata.lightmapDir = StartLightMapDir[i];
            lmdata.lightmapColor = StartLightMapColor[i];
            lmdata.shadowMask = StartLightMapShadowMask[i];
            Slightmap.Add(lmdata);
        }
        startLightMap = Slightmap.ToArray();

        List<LightmapData> Elightmap = new List<LightmapData>();
        for (int i = 0; i < EndingLightMapDir.Length; i++)
        {
            LightmapData lmdata = new LightmapData();
            lmdata.lightmapDir = EndingLightMapDir[i];
            lmdata.lightmapColor = EndingLightMapColor[i];
            lmdata.shadowMask = EndingLightMapShadowMask[i];
            Elightmap.Add(lmdata);
        }
        endingLightMap = Elightmap.ToArray();

         List<LightmapData> Dlightmap = new List<LightmapData>();
        for (int i = 0; i < DarkLightMapDir.Length; i++)
        {
            LightmapData lmdata = new LightmapData();
            lmdata.lightmapDir = DarkLightMapDir[i];
            lmdata.lightmapColor = DarkLightMapColor[i];
            lmdata.shadowMask = DarkLightMapShadowMask[i];
            Dlightmap.Add(lmdata);
        }
        darkLightMap = Elightmap.ToArray();

        
        // Reflection probes initialisieren 
 {
            LightmapSettings.lightmaps = startLightMap;

             foreach (ReflectionProbe probe in startReflectionProbes)
        {
            probe.gameObject.SetActive(true);
        }
        foreach (ReflectionProbe probe in endingReflectionProbes)
        {
            probe.gameObject.SetActive(false);
        }
         foreach (ReflectionProbe probe in darkReflectionProbes)
        {
            probe.gameObject.SetActive(false);
        }

        //lichter initialisieren 
        foreach (GameObject lights in lightsStartObj)
        {
            lights.SetActive(true);
        }
        foreach (GameObject lights in lightsEndingObj)
        {
            lights.SetActive(false);
        }
        foreach (GameObject lights in lightsOutObj)
        {
            lights.SetActive(false);
        }
            
        }
    }

    void Update()
    {
       if (trigger == 2)
        {
            LightmapSettings.lightmaps = darkLightMap;

            foreach (ReflectionProbe probe in startReflectionProbes)
            {
                probe.gameObject.SetActive(false);
            }
            foreach (ReflectionProbe probe in endingReflectionProbes)
            {
                probe.gameObject.SetActive(false);
            }
             foreach (ReflectionProbe probe in darkReflectionProbes)
            {
                probe.gameObject.SetActive(true);
            }


            foreach (GameObject lights in lightsStartObj)
            {
            lights.SetActive(false);
            }
             foreach (GameObject lights in lightsOutObj)
            {
            lights.SetActive(true);
            }
        }

        if (trigger == 3)
        {
            LightmapSettings.lightmaps = endingLightMap;

            foreach (ReflectionProbe probe in startReflectionProbes)
            {
                probe.gameObject.SetActive(false);
            }
             foreach (ReflectionProbe probe in darkReflectionProbes)
            {
                probe.gameObject.SetActive(false);
            }
            foreach (ReflectionProbe probe in endingReflectionProbes)
            {
                probe.gameObject.SetActive(true);
            }


            foreach (GameObject lights in lightsEndingObj)
            {
            lights.SetActive(true);
            }
        }
    }

    public void switchlight()
    {
        trigger = trigger +1;
    }
}