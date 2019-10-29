using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Transform pos;

    //private Sword *sword;
    //private Armour *armour;
    //private Helmet *helmet;
    // Inventory Vars //
    public InventoryObject inventory; // Set the inventory in the inspector with the Inventory ScriptableObject we created in the Editor
    private int slotLimit;


    //private Interactable *interactable;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        pos.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        pos.Translate(Input.GetAxis("Horizontal") * movSpeed, Input.GetAxis("Vertical") * movSpeed, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with an Item, and if our slotLimit is less than 10, 1 item gets added to the inventory
        var item = other.GetComponent<item>();
        if (item && slotLimit < 10)
        {
            inventory.AddItem(item._item, 1);
            Destroy(other.gameObject);
            slotLimit++;
        }
        else
        {
            Debug.Log("Cant Add Item");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with an Item, and if our slotLimit is less than 10, 1 item gets added to the inventory
        var item = other.GetComponent<item>();
        if (item && slotLimit < 10)
        {
            inventory.AddItem(item._item, 1);
            Destroy(other.gameObject);
            slotLimit++;
        }
        else
        {
            Debug.Log("Cant Add Item");
        }

    }
    // We need to clear the inventory when the game closes, or the game will remember our inventory from the previous play and produces serios problems
    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
