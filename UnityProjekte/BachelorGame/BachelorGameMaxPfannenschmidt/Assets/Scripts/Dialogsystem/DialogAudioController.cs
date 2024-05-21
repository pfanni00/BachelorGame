using System.Collections;
using UnityEngine;

public class DialogAudioController : MonoBehaviour
{
    public static DialogAudioController Instance;
    public AudioSource playerAudioSource;
    public AudioSource catAudioSource;

    public bool AudioisActive; 
    private bool DialogwasStarted;
    private bool FreeRoamDialogWasStarted;
    public Collider InitialDialogTrigger;

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
        DialogwasStarted = false;
    }

    //Dialogoption: Warum kannst du Reden? AudioFiles
    public DialogueEntry[] dialogueOption1;
    //Dialogoption: Das muss ein Traum sein. AudioFiles
    public DialogueEntry[] dialogueOption2;

    //Fütter die Katze
    public DialogueEntry[] dialogueOption3;

    // Methode zum Abspielen einer Dialogoption die zahl am ende des AudioFile Arrays muss dabei als int angegeben werden. im Switch case wird dann der Correcte Clip Abgespielt 
    public void PlayDialogueOption(int option)
    {
        switch (option)
        {
            case 1:
                StartCoroutine(PlayDialogueCoroutine(dialogueOption1));
                break;
            case 2:
                StartCoroutine(PlayDialogueCoroutine(dialogueOption2));
                break;
            case 3:
                StartCoroutine(PlayDialogueCoroutine(dialogueOption3));
                break;
            
            default:
                Debug.LogWarning("Ungültige Dialogoption ausgewählt");
                break;
        }
        //  StartCoroutine(PlayDialogueCoroutine(option == 1 ? dialogueOption1 : dialogueOption2));
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

  public void StartFreeRoamDialog()
  {
    if (DialogwasStarted == false && FreeRoamDialogWasStarted == false)
    {
    FreeRoamDialogWasStarted = true;
    StartCoroutine(FreeRoamDialog());
    }
  }

   IEnumerator FreeRoamDialog()
    {
        PlayDialogueOption(1);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(10);
        if (DialogwasStarted == false)
        {
            PlayDialogueOption(2); 
        }
    }

    public void StartFirstDialog()
    {
        StopCoroutine(FreeRoamDialog());    
        PlayDialogueOption(1);
        DialogwasStarted = true;
    }
}