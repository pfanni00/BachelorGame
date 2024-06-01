using UnityEngine;

public class lightmapChange : MonoBehaviour
{
    public Texture2D[] lightmapSet1Colors; // Array für die Lightmap-Color-Texturen der ersten Lightmap-Set
    public Texture2D[] lightmapSet2Colors; // Array für die Lightmap-Color-Texturen der zweiten Lightmap-Set
    public float transitionDuration = 1.0f; // Dauer der Transition in Sekunden

    private bool usingFirstSet = true;
    private float transitionProgress = 0.0f;
    private bool isTransitioning = false;

    void Start()
    {
        // Setze die erste Lightmap-Set beim Start
        ApplyLightmapSet(CreateLightmapData(lightmapSet1Colors));
    }

    void Update()
    {
        // Wechsel zwischen den Lightmap-Sets, wenn die Taste L gedrückt wird
        if (Input.GetKeyDown(KeyCode.L) && !isTransitioning)
        {
            StartCoroutine(SmoothTransition(usingFirstSet ? CreateLightmapData(lightmapSet2Colors) : CreateLightmapData(lightmapSet1Colors)));
            usingFirstSet = !usingFirstSet;
        }
    }

    System.Collections.IEnumerator SmoothTransition(LightmapData[] targetLightmapSet)
    {
        isTransitioning = true;
        transitionProgress = 0.0f;

        LightmapData[] initialLightmapSet = LightmapSettings.lightmaps;
        int lightmapCount = initialLightmapSet.Length;

        // Temporäre Arrays für die Transition
        LightmapData[] blendedLightmaps = new LightmapData[lightmapCount];
        for (int i = 0; i < lightmapCount; i++)
        {
            blendedLightmaps[i] = new LightmapData();
            blendedLightmaps[i].lightmapColor = new Texture2D(initialLightmapSet[i].lightmapColor.width, initialLightmapSet[i].lightmapColor.height, TextureFormat.RGBAHalf, false);
        }

        while (transitionProgress < 1.0f)
        {
            transitionProgress += Time.deltaTime / transitionDuration;
            for (int i = 0; i < lightmapCount; i++)
            {
                // Interpolation zwischen den Lightmaps
                Color[] initialColors = initialLightmapSet[i].lightmapColor.GetPixels();
                Color[] targetColors = targetLightmapSet[i].lightmapColor.GetPixels();
                Color[] blendedColors = new Color[initialColors.Length];

                for (int j = 0; j < initialColors.Length; j++)
                {
                    blendedColors[j] = Color.Lerp(initialColors[j], targetColors[j], transitionProgress);
                }

                blendedLightmaps[i].lightmapColor.SetPixels(blendedColors);
                blendedLightmaps[i].lightmapColor.Apply();
            }

            LightmapSettings.lightmaps = blendedLightmaps;
            yield return null;
        }

        // Endgültige Lightmap-Set anwenden
        ApplyLightmapSet(targetLightmapSet);
        isTransitioning = false;
    }

    void ApplyLightmapSet(LightmapData[] lightmapSet)
    {
        LightmapSettings.lightmaps = lightmapSet;
    }

    LightmapData[] CreateLightmapData(Texture2D[] lightmapColors)
    {
        LightmapData[] lightmapDataArray = new LightmapData[lightmapColors.Length];
        for (int i = 0; i < lightmapColors.Length; i++)
        {
            lightmapDataArray[i] = new LightmapData
            {
                lightmapColor = lightmapColors[i]
            };
        }
        return lightmapDataArray;
    }
}