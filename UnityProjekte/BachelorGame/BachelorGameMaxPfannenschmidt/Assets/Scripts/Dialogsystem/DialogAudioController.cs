using System.Collections;
using UnityEngine;

public class DialogAudioController : MonoBehaviour
{
    public static DialogAudioController Instance;
    public AudioSource playerAudioSource;
    public AudioSource catAudioSource;

    public bool AudioisActive; 

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
        AudioisActive = false;
    }

    //Dialogoption: Warum kannst du Reden? AudioFiles
    public DialogueEntry[] dialogueOption1;
    //Dialogoption: Das muss ein Traum sein. AudioFiles
    public DialogueEntry[] dialogueOption2;

    // Methode zum Abspielen einer Dialogoption die zahl am ende des AudioFile Arrays muss dabei als int angegeben werden. 
    public void PlayDialogueOption(int option)
    {
        StartCoroutine(PlayDialogueCoroutine(option == 1 ? dialogueOption1 : dialogueOption2));
    }

    // Koroutine zum sequenziellen Abspielen der Dialoge
    private IEnumerator PlayDialogueCoroutine(DialogueEntry[] dialogueEntries)
    {
        AudioisActive = true;
        foreach (var entry in dialogueEntries)
        {
            AudioSource currentSource = entry.isPlayer ? playerAudioSource : catAudioSource;
            currentSource.clip = entry.clip;
            currentSource.Play();
            yield return new WaitForSeconds(entry.clip.length + 0.2f); // Wartezeit nach jedem Clip
        }
        AudioisActive = false;

    }
}