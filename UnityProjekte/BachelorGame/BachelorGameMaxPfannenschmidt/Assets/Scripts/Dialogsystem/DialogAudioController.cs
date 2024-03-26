using System.Collections;
using UnityEngine;

public class DialogAudioController : MonoBehaviour
{
    public static DialogAudioController Instance;
    public AudioSource playerAudioSource;
    public AudioSource catAudioSource;

    // Struktur, um einen Dialogeintrag zu definieren
    [System.Serializable]
    public struct DialogueEntry
    {
        public AudioClip clip;
        public bool isPlayer; // Wenn true, ist der Sprecher der Player; wenn false, die Katze
    }

    void Awake()
    {
        Instance = this;
    }

    // Zwei Arrays für die Dialogoptionen
    public DialogueEntry[] dialogueOption1;
    public DialogueEntry[] dialogueOption2;

    // Methode zum Abspielen einer Dialogoption
    public void PlayDialogueOption(int option)
    {
        StartCoroutine(PlayDialogueCoroutine(option == 1 ? dialogueOption1 : dialogueOption2));
    }

    // Koroutine zum sequenziellen Abspielen der Dialoge
    private IEnumerator PlayDialogueCoroutine(DialogueEntry[] dialogueEntries)
    {
        foreach (var entry in dialogueEntries)
        {
            AudioSource currentSource = entry.isPlayer ? playerAudioSource : catAudioSource;
            currentSource.clip = entry.clip;
            currentSource.Play();
            yield return new WaitForSeconds(entry.clip.length + 0.5f); // Wartezeit nach jedem Clip
        }
    }
}