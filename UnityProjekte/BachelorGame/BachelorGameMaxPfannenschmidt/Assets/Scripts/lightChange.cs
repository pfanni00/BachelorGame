using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChange : MonoBehaviour
{
    public bool trigger;
    public Texture2D[] StartLightMapDir, StartLightMapColor, StartLightMapShadowMask;
    public Texture2D[] EndingLightMapDir, EndingLightMapColor, EndingLightMapShadowMask;

    private LightmapData[] startLightMap, endingLightMap;

    // Start is called before the first frame update
    void Start()
    {
        trigger = false;

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
    }

    void Update()
    {
        if (trigger == false)
        {
            LightmapSettings.lightmaps = startLightMap;
        }
        else if (trigger == true)
        {
            LightmapSettings.lightmaps = endingLightMap;
        }
    }
}