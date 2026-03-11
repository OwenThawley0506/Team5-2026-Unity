using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;  

    private void Awake()
    {
        instance = this;
        if (instance == null)
        {
            Debug.LogWarning("found more than one dialogue manager in this scene");
        }

    }

    public static DialogueManager getInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        //return right away if dialogue isnt playing.
        if (!dialogueIsPlaying)
        {
            return;
        }

        //handle continueing to the next line in the dialogue when submit is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            ContinueStory();
        }
    }

    //when player interacts with the talkable character, the dialogue panel will pop up and the dialogue will start
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    //finishes current dialogue and exits dialogue mode
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    //checking is story can continue, if it can, then show the next line of dialogue
     private void ContinueStory()
     {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
     }
}
