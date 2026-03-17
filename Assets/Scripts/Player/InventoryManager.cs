using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool MenuActive;
    public ItemSlot[] itemSlot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.getInstance().submitPressed && MenuActive)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            MenuActive = false;
        }

        else if (InputManager.getInstance().submitPressed && !MenuActive)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            MenuActive = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
       for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                return;
            }
        }
    }
}
