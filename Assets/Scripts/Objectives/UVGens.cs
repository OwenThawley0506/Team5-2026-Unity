using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UVGen : MonoBehaviour
{
    Player player;
    public bool isUVGenOn = false;
    public bool isPlayerInRange = false;
    [SerializeField] private int howDifficultToFixGen = 20;
    [SerializeField] private int GensProgress = 0;


    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //set player.hasCanister to Player inventory is full/Empty
        if (player.hasCanister == true && player.hasHammer == false && isPlayerInRange && InputManager.getInstance().interactPressed && isUVGenOn == false)
        {
                //Start repairing the generator and update progress bar
                //loat)GensProgress / howDifficultToFixGen;
                Debug.Log(GensProgress);  
                GensProgress ++;

                // remove item in inventory when player uses canister on generator
                if (GensProgress >= howDifficultToFixGen)
                {
                    //What happens when gen is completely repaired
                    isUVGenOn = true;
                    player.hasCanister = false;
                    Debug.Log("UV Generator is now on: " + isUVGenOn);
                    Debug.Log("Player has canister: " + player.hasCanister);
                    GensProgress = 0; // reset progress after repairs are done
                    isPlayerInRange = false; // player can only repair once per range entry
                    //progressBar.enabled = false;
                }
        }
        if (player.hasCanister == false && isPlayerInRange && InputManager.getInstance().interactPressed && isUVGenOn == false)
        {
            Debug.Log("Player does not have the right item to repair the UV generator.");
        }
        if (isUVGenOn == true && isPlayerInRange && InputManager.getInstance().interactPressed)
        {
            Debug.Log("UV Generator is already on, no need to repair.");
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
