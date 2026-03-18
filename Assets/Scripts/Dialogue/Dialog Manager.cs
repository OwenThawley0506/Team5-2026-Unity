using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject portraitAnimator;
    private Animator layoutAnimator;
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

        layoutAnimator = dialoguePanel.GetComponent<Animator>();        
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

        //resets portrait, layout, and speaker
        displayNameText.text = "";
        portraitAnimator.GetComponent<Animator>().Play("default");
        layoutAnimator.Play("left");
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
                    displayNameText.text = tagValue;
                    break;
                    //handle portrait tag
                case Portrait_Tag:
                    portraitAnimator.GetComponent<Animator>().Play(tagValue);
                    break;
                    //handle layout tag
                case Layout_Tag:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is currently not beinghandled: " + tag);
                    break;
            }
        } 
     }
}
