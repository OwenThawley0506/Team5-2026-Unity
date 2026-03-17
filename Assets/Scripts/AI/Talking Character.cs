using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingCharacter : MonoBehaviour
{
    [Header("Visua Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        // this is here to set as a start, when codeing later, have this start as false and only set when needs be
        visualCue.SetActive(true); 
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.getInstance().dialogueIsPlaying)
        {
            if(InputManager.getInstance().interactPressed)
            {
                visualCue.SetActive(false);
                DialogueManager.getInstance().EnterDialogueMode(inkJSON);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInRange = false;
        }
    }
}
