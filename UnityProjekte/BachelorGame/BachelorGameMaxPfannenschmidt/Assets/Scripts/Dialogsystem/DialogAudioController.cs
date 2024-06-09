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
        public DialogueEntry[] FreeRoamDialogNUM1;
    //FreeRoamDialog2 AudioFiles
        public DialogueEntry[] FreeRoamDialogNUM2;
    //KatzeStartDialog AudioFiles
        public DialogueEntry[] KatzeStartDialogNUM3;
    //Dialogoption: Warum Kannst du Reden? AudioFiles
        public DialogueEntry[] WarumKannstDuRedenNUM4;
    //Dialogoption: FütterDieKatze AudioFiles
        public DialogueEntry[] FütterDieKatzeNUM5;
    //Spawn Dialog
        public DialogueEntry[] SpawnDialogNUM6;
    //Dialogoption: Das muss ein Traum sein
        public DialogueEntry[] DasMussEinTraumSeinNUM7;
    //Dialogoption: Naja, dann rede ich jetzt wohl mit einer Katze
        public DialogueEntry[] DannRedeIchMitEinerKatzeNUM8;
    //Dialogoption Das ist doch alles verrückt, ich muss aufwachen!
        public DialogueEntry[] ichMussAufwachenNUM9;
    //Dialogoption Wo ist Emma?
        public DialogueEntry[] WoIstEmmaNUM10;
    //Dialogoption Wie Bin ich Hierhergekommen?
        public DialogueEntry[] WieBinIchHierhergekommenNUM11;
    //Dialogoption Bin ich Tot? Variante Dumm
        public DialogueEntry[] BinIchTodDummNUM12;
    //Dialogoption Bin ich Tot? Variante Schlau
        public DialogueEntry[] BinIchTodSchlauNUM13;
    //Dialogoption Was Jetzt? Variante Schlau
        public DialogueEntry[] WasJetztSchlauNUM14;
    //Dialogoption Was Jetzt? Variante Dumm
        public DialogueEntry[] WasJetztDummNUM15;
    //Dialogoption Frag nach Brief an Emmas Mutter
        public DialogueEntry[] FragNachBriefNUM16;
    //Dialogoption Frag nach EmmasTagebuch
        public DialogueEntry[] FragNachTagebuchNUM17; 
    //Dialogoption Frag nach deinem Koma
        public DialogueEntry[] FragNachKomaNUM18; 
    //Dialogoption Ich wäre mein leben lang eine last. Variante Schlau
        public DialogueEntry[] IchWäreEineLastSchlauNUM19;      
    //Dialogoption Ich wäre mein leben lang eine last. Variante Dumm
        public DialogueEntry[] IchWäreEineLastDummNUM20;
    //Dialogoption Ich wäre mein leben lang eine last. Variante Schlau NICHT ALLE ITEMS 
        public DialogueEntry[] IchWäreEineLastSchlauNichtAlleITEMSNUM21;
    //Dialogoption Ich wäre mein leben lang eine last. Variante Dumm NICHT ALLE ITEMS 
        public DialogueEntry[] IchWäreEineLastDummNichtAlleITEMSNUM22;
 //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau NICHT ALLE ITEMS 
        public DialogueEntry[] IchWillEmmaNichtVerlierenSchlauNUM23;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau
        public DialogueEntry[] IchWillEmmaNichtVerlierenDummNUM24;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau 
        public DialogueEntry[] IchWillEmmaNichtVerlierenSchlauNichtAlleITEMSNUM25;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau NICHT ALLE ITEMS 
        public DialogueEntry[] IchWillEmmaNichtVerlierenDummNichtAlleITEMSNUM26;


    // Methode zum Abspielen einer Dialogoption die zahl am ende des AudioFile Arrays muss dabei als int angegeben werden. im Switch case wird dann der Correcte Clip Abgespielt 
    public void PlayDialogueOption(int option)
    {
        switch (option)
        {
            case 1:
                StartCoroutine(PlayDialogueCoroutine(FreeRoamDialogNUM1));
                break;
            case 2:
                StartCoroutine(PlayDialogueCoroutine(FreeRoamDialogNUM2));
                break;
            case 3:
                StartCoroutine(PlayDialogueCoroutine(KatzeStartDialogNUM3));
                break;
            case 4:
                StartCoroutine(PlayDialogueCoroutine(WarumKannstDuRedenNUM4));
                break;
            case 5:
                StartCoroutine(PlayDialogueCoroutine(FütterDieKatzeNUM5));
                break;
            case 6:
                StartCoroutine(PlayDialogueCoroutine(SpawnDialogNUM6));
                break;
            case 7:
                StartCoroutine(PlayDialogueCoroutine(DasMussEinTraumSeinNUM7));
                break;
            case 8:
                StartCoroutine(PlayDialogueCoroutine(DannRedeIchMitEinerKatzeNUM8));
                break;
            case 9:
                StartCoroutine(PlayDialogueCoroutine(ichMussAufwachenNUM9));
                break;
            case 10:
                StartCoroutine(PlayDialogueCoroutine(WoIstEmmaNUM10));
                break;
            case 11:
                StartCoroutine(PlayDialogueCoroutine(WieBinIchHierhergekommenNUM11));
                break;
            case 12:
                StartCoroutine(PlayDialogueCoroutine(BinIchTodDummNUM12));
                break;
            case 13:
                StartCoroutine(PlayDialogueCoroutine(BinIchTodSchlauNUM13));
                break;
            case 14:
                StartCoroutine(PlayDialogueCoroutine(WasJetztSchlauNUM14));
                break;
            case 15:
                StartCoroutine(PlayDialogueCoroutine(WasJetztDummNUM15));
                break;
            case 16:
                StartCoroutine(PlayDialogueCoroutine(FragNachBriefNUM16));
                break;
            case 17:
                StartCoroutine(PlayDialogueCoroutine(FragNachTagebuchNUM17));
                break;
            case 18:
                StartCoroutine(PlayDialogueCoroutine(FragNachKomaNUM18));
                break;
            case 19:
                StartCoroutine(PlayDialogueCoroutine(IchWäreEineLastSchlauNUM19));
                break;
            case 20:
                StartCoroutine(PlayDialogueCoroutine(IchWäreEineLastDummNUM20));
                break;
            default:
            case 21:
                StartCoroutine(PlayDialogueCoroutine(IchWäreEineLastSchlauNichtAlleITEMSNUM21));
                break;
            case 22:
                StartCoroutine(PlayDialogueCoroutine(IchWäreEineLastDummNichtAlleITEMSNUM22));
                break;
            case 23:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenSchlauNUM23));
                break;
            case 24:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenDummNUM24));
                break;
            case 25:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenSchlauNichtAlleITEMSNUM25));
                break;
            case 26:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenDummNichtAlleITEMSNUM26));
                break;
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