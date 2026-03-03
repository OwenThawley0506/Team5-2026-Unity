using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    //===ITEM SLOT===//
    [SerializeField] private Image itemImage;

    //===DESCRIPTION===//
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;


    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;
        
        
        itemImage.sprite = itemSprite;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;

    }

}
