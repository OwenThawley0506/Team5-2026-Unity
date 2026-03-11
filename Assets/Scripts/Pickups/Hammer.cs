using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    Player player;
    Hammer hammer;
    public Hammer()
    {

        return;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if(collision.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (player.hasCanister == false && player.hasHammer == false)
            {
                player.hasHammer = true;
                Debug.Log("Player has Hammer: " + player.hasHammer); 
            }
            else if (player.hasCanister == true || player.hasHammer == true)
            {
                Debug.Log("Inventory full, cannot pick up hammer.");
            }

        }
    }
}
