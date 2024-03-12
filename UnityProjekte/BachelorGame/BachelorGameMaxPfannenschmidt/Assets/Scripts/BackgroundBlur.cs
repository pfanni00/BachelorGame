using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundBlur : MonoBehaviour
{
    public Volume m_Volume;
    public float duration;
    private void Start()
    {
        // Optional: Starte die FadeOut Funktion zum Testen
        // StartCoroutine(FadeOut());
    }

    public void StartFadeOut()
    {
        // Startet die Coroutine, um den FadeOut Effekt zu beginnen
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {

        if (m_Volume == null)
            yield break; // Beendet die Coroutine, falls m_Volume nicht gesetzt ist

        float currentTime = 0f; // Aktuelle Zeit, startet bei 0

        // Speichere den aktuellen weight Wert, um von diesem Wert zu beginnen
        float startWeight = m_Volume.weight;
        float goalweight = 0f;
        
        if (startWeight != goalweight)
        {

        while (currentTime < duration)
        {
            // Aktualisiere die verstrichene Zeit
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
            // Aktualisiere den weight Wert von m_Volume
            m_Volume.weight = Mathf.SmoothStep(startWeight, goalweight, currentTime / duration);
            yield return null; // Warte bis zum nächsten Frame
        }
        }
    }

    public void StartFadeIn()
    {
        // Startet die Coroutine, um den FadeOut Effekt zu beginnen
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        if (m_Volume == null)
            yield break; // Beendet die Coroutine, falls m_Volume nicht gesetzt ist

        float currentTime = 0f; // Aktuelle Zeit, startet bei 0

        // Speichere den aktuellen weight Wert, um von diesem Wert zu beginnen
        float startWeight = m_Volume.weight;
        float goalweight = 1f;

        if (startWeight != goalweight)
        {

        while (currentTime < duration)
        {
            // Aktualisiere die verstrichene Zeit
            currentTime += Time.deltaTime;
                        Debug.Log(currentTime);

            // Aktualisiere den weight Wert von m_Volume
            m_Volume.weight = Mathf.SmoothStep(startWeight, goalweight, currentTime / duration);
            yield return null; // Warte bis zum nächsten Frame
        }}
    }
}