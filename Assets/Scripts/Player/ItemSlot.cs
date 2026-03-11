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

    public Sprite emptySprite;

    //===ITEM SLOT===//
    [SerializeField] private Image itemImage;



    //===DESCRIPTION===//
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;


    private void Update()
    {
        if (Input.GetButtonDown("DropItem"))
        {
            DropItem();
        }
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //update name
        this.itemName = itemName;
        //update quantity
        this.quantity = quantity;
        //update image
        this.itemSprite = itemSprite;
        //update description
        this.itemDescription = itemDescription;
        isFull = true;


        itemImage.sprite = itemSprite;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;

    }

    public void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
    }

    public void DropItem()
    {
        if (isFull == true)
        {
            GameObject itemToDrop = new GameObject(itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.itemName = itemName;
            newItem.quantity = quantity;
            newItem.sprite = itemSprite;
            newItem.itemDescription = itemDescription;



            //===SPRITE RENDERER===//
            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = itemSprite;
            sr.sortingOrder = 5;
            sr.sortingLayerName = "Ground";

            //===BOX COLLIDER===//
            itemToDrop.AddComponent<BoxCollider2D>();

            //===SET POSITION===//
            itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(2, 0, 0);

            //===CLEAR ITEM SLOT===//
            EmptySlot();

            isFull = false;
            return;

        }
    }




}
