using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundBlur : MonoBehaviour
{
    // Referenz auf das Volume-Objekt, das den Post-Processing-Effekt enthält
    public Volume m_Volume;

    // Dauer für den Fade-Out- und Fade-In-Effekt
    public float duration;

    // Dauer für den initialen Fade-Out-Effekt
    public float startduration;
    
    

    public void StartFadeOut()
    {
        // Startet die Coroutine, um den FadeOut Effekt zu beginnen
        StartCoroutine(FadeOut(duration));
    }

    // Funktion die zu beginn des Spiels die schärfe langsam hochstellt
    public void initialFadeOut()
    {
        StartCoroutine(FadeOut(startduration));
    }


    IEnumerator FadeOut(float selectedDuration)
    {

        if (m_Volume == null)
            yield break; // Beendet die Coroutine, falls m_Volume nicht gesetzt ist
            
        float currentTime = 0f; // Aktuelle Zeit, startet bei 0

        // Speichere den aktuellen weight Wert, um von diesem Wert zu beginnen
        float startWeight = m_Volume.weight;
        // Zielwert des Weights
        float goalweight = 0f;
        
        if (startWeight != goalweight)
        {

        while (currentTime < selectedDuration)
        {
            // timer läuft solange er nicht der selectedDuration entspricht 
            currentTime += Time.deltaTime;

            // Aktualisiere den weight Wert von m_Volume
            m_Volume.weight = Mathf.SmoothStep(startWeight, goalweight, currentTime / selectedDuration);
            yield return null; // Warte bis zum nächsten Frame
        }
        }
    }

    public void StartFadeIn()
    {
        // Startet die Coroutine, um den FadeOut Effekt zu beginnen
        StartCoroutine(FadeIn(duration));
    }

    IEnumerator FadeIn(float selectedDuration)
    {
        if (m_Volume == null)
            yield break; // Beendet die Coroutine, falls m_Volume nicht gesetzt ist

        float currentTime = 0f; // Aktuelle Zeit, startet bei 0

        // Speichere den aktuellen weight Wert, um von diesem Wert zu beginnen
        float startWeight = m_Volume.weight + 0.6f;

        // Zielwert des Weights
        float goalweight = 1f;

        if (startWeight != goalweight)
        {

        while (currentTime < selectedDuration)
        {
            // timer läuft solange er nicht der selectedDuration entspricht 
            currentTime += Time.deltaTime;

            // Aktualisiere den weight Wert von m_Volume
            m_Volume.weight = Mathf.SmoothStep(startWeight, goalweight, currentTime / selectedDuration);
            yield return null; // Warte bis zum nächsten Frame
        }}
    }
}