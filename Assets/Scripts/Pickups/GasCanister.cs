using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanistor : MonoBehaviour
{
    Player player;
    GasCanistor gasCanistor;
    public GasCanistor()
    {

        return;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {        
        player = collision.gameObject.GetComponent<Player>();
        if(collision.gameObject.name == "Player" && InputManager.getInstance().interactPressed)
        {
            if (player.hasCanister == false && player.hasHammer == false)
            {
                player.hasCanister = true;
                Debug.Log("Player has canister: " + player.hasCanister); 
            }
            else if (player.hasCanister == true || player.hasHammer == true)
            {
                Debug.Log("Inventory full, cannot pick up canister.");
            }

        }
        
    }
}
