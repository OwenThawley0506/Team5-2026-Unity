using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SearchService;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;
    private object splitTag;
    private const string Speaker_Tag = "Speaker";
    private const string Portrait_Tag = "Portrait";
    private const string Layout_Tag = "Layout";
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
        if (InputManager.getInstance().GetSubmitPressed())
        {
            Debug.Log("Submit Pressed, continuing story");
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
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
     }
     private void HandleTags(List<string> currentTags)
     {
        //loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {
            //split the tag into its name and value (if it has a value)
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriatly split: " + tag);
            }

        string tagKey = splitTag[0].Trim();
        string tagValue = splitTag[1].Trim();

            //Handle the tag
            switch (tagKey)
            {
                //handle speaker tag
                case Speaker_Tag:
                    Debug.Log("speaker tag value: " + tagValue);
                    break;
                    //handle portrait tag
                case Portrait_Tag:
                    Debug.Log("portrait tag value: " + tagValue);
                    break;
                    //handle layout tag
                case Layout_Tag:
                    Debug.Log("layout tag value: " + tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is currently not beinghandled: " + tag);
                    break;
            }
        } 
     }
}
