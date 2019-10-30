using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static bool gamePaused = false;       // Pausing for inventory


    public GameObject inventoryUI;
    public GameObject hotbarUI;
    private Transform pos;

    //private Sword *sword;
    //private Armour *armour;
    //private Helmet *helmet;


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

    private void FixedUpdate()
    {
        pos.Translate(Input.GetAxis("Horizontal") * movSpeed, Input.GetAxis("Vertical") * movSpeed, 0f);

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }

        if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Cancel"))
        {
            if (gamePaused)
            {
                hotbarUI.SetActive(true);
                Time.timeScale = 1f;
                inventoryUI.SetActive(false);
                gamePaused = false;
            }
            else
            {
                hotbarUI.SetActive(false);
                Time.timeScale = 0f;
                inventoryUI.SetActive(true);
                gamePaused = true;

            }
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with an Item, and if our slotLimit is less than 10, 1 item gets added to the inventory
        if (other.gameObject.CompareTag("Item") && slotLimit < 12)
        {
            var item = other.GetComponent<Grounditem>();
            inventory.AddItem(new item(item._item), 1);
            Destroy(other.gameObject);
            slotLimit++;
        }
        else
        {
            Debug.Log("Cant Add Item");
        }
        
         if (other.gameObject.tag == "Interactable")
        {
          interactable = other.gameObject.GetComponent<Interactable>();
        }
        if (other.gameObject.tag == "Enemy")
        {
            target = other.gameObject.GetComponent<Enemy>();
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
