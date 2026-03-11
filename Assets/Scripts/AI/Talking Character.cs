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
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.getInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                DialogueManager.getInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
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
