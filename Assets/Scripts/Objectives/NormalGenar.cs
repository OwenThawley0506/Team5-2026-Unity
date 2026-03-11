using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class NormalGen : MonoBehaviour
{   
    Player player;
    public bool isnormalGenOn = false;
    public bool isPlayerInRange = false;
    [SerializeField] private int howDifficultToFixGen = 20;
    [SerializeField] private int GensProgress = 0;


    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //set player.hasHammer to Player inventory is full/Empty
        if (player.hasHammer == true && player.hasCanister == false && isPlayerInRange && Input.GetKeyDown(KeyCode.F) && isnormalGenOn == false)
        {
            {
                //Start repairing the generator and update progress bar
                //progressBar.enabled = true;
                //progressBar.fillAmount = (float)GensProgress / howDifficultToFixGen;
                Debug.Log(GensProgress);  
                GensProgress ++;

                // remove item in inventory when player uses hammer on generator
                if (GensProgress >= howDifficultToFixGen)
                {
                    //What happens when gen is completely repaired
                    isnormalGenOn = true;
                    player.hasHammer = false;
                    Debug.Log("Normal Generator is now on: " + isnormalGenOn);
                    Debug.Log("Player has hammer: " + player.hasHammer);
                    GensProgress = 0; // reset progress after repairs are done
                    isPlayerInRange = false; // player can only repair once per range entry
                    //progressBar.enabled = false;
                }
            }
        }        
        if (player.hasHammer == false && isPlayerInRange && Input.GetKeyDown(KeyCode.F) && isnormalGenOn == false)
        {
            Debug.Log("Player does not have the right item to repair the normal generator.");
        }
        if (isnormalGenOn == true && isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Normal Generator is already on, no need to repair.");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isPlayerInRange = false;
            // reset progress if player leaves the range
            GensProgress = 0;
            //progressBar.enabled = false;
        }
    }
}
