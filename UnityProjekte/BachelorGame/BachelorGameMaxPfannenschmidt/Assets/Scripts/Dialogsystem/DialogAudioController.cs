using System.Collections;
using UnityEngine;

public class DialogAudioController : MonoBehaviour
{// Dieses Script spielt die Dialoge zwischen Marcell und der Katze ab

    public static DialogAudioController Instance;
    
    // referenz zur AudioSource des Players
    public AudioSource playerAudioSource;
    
    // referenz zur AudioSource der Katze 
    public AudioSource catAudioSource;

    // gibt an ob Audio gerade abgespielt wird
    public bool AudioisActive; 

    // gibt an ob der Dialogbereits gestarted wurde
    public bool DialogwasStarted;

    // gibt an ob FreeRoamDialog gestarted wurde (Wenn spieler zimmer verlässt spricht katze ihn an) 
    private bool FreeRoamDialogWasStarted;

    // collider welcher den FreeRoamDialogStarted 
    public Collider InitialDialogTrigger;

    // Struktur, um einen Dialogeintrag zu definieren
    [System.Serializable]
    public struct DialogueEntry
    {
        // abzuspielender Audio Clip
        public AudioClip clip;
        // Gibt an welche AudioSource genutzt werden soll. Wenn true, ist der Sprecher der Player; wenn false, die Katze
        public bool isPlayer; 
    }


    void Awake()
    {
        Instance = this;
        AudioisActive = false;
        DialogwasStarted = false;
    }

// Audio zu den Dialogoptionen 

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
    //Dialogoption Ich wäre mein leben lang eine last. Variante Schlau  ALLE ITEMS 
        public DialogueEntry[] IchWäreEineLastSchlauAlleITEMSNUM21;
    //Dialogoption Ich wäre mein leben lang eine last. Variante Dumm  ALLE ITEMS 
        public DialogueEntry[] IchWäreEineLastDummAlleITEMSNUM22;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau  ALLE ITEMS 
        public DialogueEntry[] IchWillEmmaNichtVerlierenSchlauNUM23;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau
        public DialogueEntry[] IchWillEmmaNichtVerlierenDummNUM24;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Dumm 
        public DialogueEntry[] IchWillEmmaNichtVerlierenSchlauAlleITEMSNUM25;
    //Dialogoption Ich WillEmmaNichtVerlieren Variante Schlau  ALLE ITEMS 
        public DialogueEntry[] IchWillEmmaNichtVerlierenDummAlleITEMSNUM26;


    // Methode zum Abspielen einer Dialogoption die zahl am ende des AudioFile Arrays muss dabei als "option" angegeben werden. im Switch case wird dann der Correcte Clip Abgespielt 
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
                StartCoroutine(PlayDialogueCoroutine(IchWäreEineLastSchlauAlleITEMSNUM21));
                break;
            case 22:
                StartCoroutine(PlayDialogueCoroutine(IchWäreEineLastDummAlleITEMSNUM22));
                break;
            case 23:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenSchlauNUM23));
                break;
            case 24:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenDummNUM24));
                break;
            case 25:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenSchlauAlleITEMSNUM25));
                break;
            case 26:
                StartCoroutine(PlayDialogueCoroutine(IchWillEmmaNichtVerlierenDummAlleITEMSNUM26));
                break;
               
        }
    }

    // Coroutine zum sequenziellen Abspielen der Dialoge
    private IEnumerator PlayDialogueCoroutine(DialogueEntry[] dialogueEntries)
    {
        // AudioisActive ist true für die dauer der Coroutine
        AudioisActive = true;

        //jeder AudioClip der dialogueEtrie wird nacheinander abgespielt
        foreach (var entry in dialogueEntries)
        {
            // AudioSource wird bestimmt und zugewiesen
            AudioSource currentSource = entry.isPlayer ? playerAudioSource : catAudioSource;
            //audioClip wird der AudioSource zugewiesen
            currentSource.clip = entry.clip;
            //Audio wird abgespielt 
            currentSource.Play();
            //warten bis clip vorbei ist.
            yield return new WaitForSeconds(entry.clip.length + 0.2f); // Wartezeit nach jedem Clip
        }
        AudioisActive = false;

    }

// funktion um FreeRoamDialog zu starten 
  public void StartFreeRoamDialog()
  {
    // Dialog Started nur wenn FreeRoamDialog und Dialog noch nicht gestarted wurde
    if (DialogwasStarted == false && FreeRoamDialogWasStarted == false)
    {
       
        
        // FreeRoamDialogwird abgespielt variable wird auf true gesetzt um erneutes Abspielen zu verhindern 
        FreeRoamDialogWasStarted = true;
        StartCoroutine(FreeRoamDialog());

    }
  }

   IEnumerator FreeRoamDialog()
    {
        // Dialogsystem ist für dauer des FreeRoamDialogs nicht nutzbar
        DialogsystemManager.Instance.DialogsystemIsUsabale = false;

        //Audio wird Abgespielt
        PlayDialogueOption(1);
        // nach ende der Audio ist Dialogsystem wieder nutzbar
        DialogsystemManager.Instance.DialogsystemIsUsabale = true;

        // Wenn der Spieler nach 10 secunden noch nicht mit der Katze gesprochen hat, wird ein weiterer Audio Clip abgespielt 
        yield return new WaitForSeconds(10);
        if (DialogwasStarted == false)
        {
            // Dialogsystem ist für dauer des FreeRoamDialogs nicht nutzbar
            DialogsystemManager.Instance.DialogsystemIsUsabale = false;
            
            //Audio wird Abgespielt
            PlayDialogueOption(2);
            // nach ende der Audio ist Dialogsystem wieder nutzbar
            DialogsystemManager.Instance.DialogsystemIsUsabale = true;

        }
    }

// diese funktion started den initial dialog dieser wird bei der ersten interaktion mit der Katze gestarted.
    public void StartFirstDialog()
    {
        // FreeRoam Dialog wird gestoppt
        StopCoroutine(FreeRoamDialog());
        // Audio wird Abgespielt
        PlayDialogueOption(3);
        // variable speichert das Dialog gestarted wurde
        DialogwasStarted = true;
    }
}