using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanister : MonoBehaviour
{
    Player player;
    GasCanister gasCanister;
    public GasCanister()
    {

        return;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {        
        player = collision.gameObject.GetComponent<Player>();
        if(collision.gameObject.name == "Player" && InputManager.getInstance().GetInteractPressed())
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
