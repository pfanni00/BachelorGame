using System.Collections;
using UnityEngine;

public class DialogAudioController : MonoBehaviour
{
    public static DialogAudioController Instance;
    public AudioSource playerAudioSource;
    public AudioSource catAudioSource;

    public bool AudioisActive; 
    public bool DialogwasStarted;
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

    // FreeRoamDialog1 AudioFiles
    public DialogueEntry[] dialogueOption1;
    //FreeRoamDialog2 AudioFiles
    public DialogueEntry[] dialogueOption2;
    //KatzeStartDialog AudioFiles
    public DialogueEntry[] dialogueOption3;
    //Dialogoption: Warum Kannst du Reden? AudioFiles
    public DialogueEntry[] dialogueOption4;
    //Dialogoption: F�tterDieKatze AudioFiles
    public DialogueEntry[] dialogueOption5;

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
            case 4:
                StartCoroutine(PlayDialogueCoroutine(dialogueOption4));
                break;
            case 5:
                StartCoroutine(PlayDialogueCoroutine(dialogueOption5));
                break;
            default:
                Debug.LogWarning("Ung�ltige Dialogoption ausgew�hlt");
                break;
        }
        //  StartCoroutine(PlayDialogueCoroutine(option == 1 ? dialogueOption1 : dialogueOption2));
    }

    // Coroutine zum sequenziellen Abspielen der Dialoge
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
    DialogsystemManager.Instance.DialogsystemIsUsabale = false;
    FreeRoamDialogWasStarted = true;
    StartCoroutine(FreeRoamDialog());

        }
    }

   IEnumerator FreeRoamDialog()
    {
        DialogsystemManager.Instance.DialogsystemIsUsabale = false;

        PlayDialogueOption(1);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        DialogsystemManager.Instance.DialogsystemIsUsabale = true;

        yield return new WaitForSeconds(10);
        if (DialogwasStarted == false)
        {
            DialogsystemManager.Instance.DialogsystemIsUsabale = false;

            PlayDialogueOption(2);
            DialogsystemManager.Instance.DialogsystemIsUsabale = true;

        }
    }

    public void StartFirstDialog()
    {
        StopCoroutine(FreeRoamDialog());    
        PlayDialogueOption(3);
        DialogwasStarted = true;
    }
}