using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Transform pos;

    //private Sword *sword;
    //private Armour *armour;
    //private Helmet *helmet;

    //private Inventory *inventory;
    private Interactable interactable;


    // Inventory Vars //
    public InventoryObject inventory; // Set the inventory in the inspector with the Inventory ScriptableObject we created in the Editor
    private int slotLimit;



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

    private void OnTriggerEnter(Collider response)
    {
        // If the player collides with an Item, and if our slotLimit is less than 10, 1 item gets added to the inventory
        var item = response.GetComponent<Grounditem>();
        if (item && slotLimit < 10)
        {
            inventory.AddItem(new item(item._item), 1);
            Destroy(response.gameObject);
            slotLimit++;
        }
        else
        {
            Debug.Log("Cant Add Item");
        }
        
         if (response.gameObject.tag == "Interactable")
        {
          interactable = response.gameObject.GetComponent<Interactable>();
        }
        if (response.gameObject.tag == "Enemy")
        {
            target = response.gameObject.GetComponent<Enemy>();
        }
    }
    

       

    private void OnTriggerExit(Collider response)
    {
        if (response.gameObject.GetComponent<Interactable>() == interactable)
        {
            interactable = null;
        }
    }

    protected override void Attack()
    {

    }

    protected override void Die()
    {
        //restart level
    }

    private void Interact()
    {
        if (interactable != null)
        {
            interactable.act();
        }
    }
        // We need to clear the inventory when the game closes, or the game will remember our inventory from the previous play and produces serios problems
    private void OnApplicationQuit()
    {
        inventory.container.items.Clear();
    }
}
