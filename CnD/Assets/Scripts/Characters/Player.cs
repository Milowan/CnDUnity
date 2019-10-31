using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public static bool gamePaused = false;       // Pausing for inventory

    private GemItem gem;
    public GameObject inventoryUI;
    public GameObject hotbarUI;
    private Transform pos;
    //private Sword *sword;
    //private Armour *armour;
    //private Helmet *helmet;


    private Interactable interactable;

    // Inventory Vars //
    public InventoryObject inventory; // Set the inventory in the inspector with the Inventory ScriptableObject we created in the Editor
    public InventoryObject GemsInventory;

    private int slotLimit;



    // Start is called before the first frame update
    void Start()
    {
        movSpeed = 0.2f;
        stats = new Stats();
        SetStats();
        maxHealth = 50;
        health = maxHealth;
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

        if (Input.GetButtonDown("MainAtk"))
        {
            Attack();
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
            if ( gem == other.gameObject.GetComponent<GemItem>())
            {
                gem.SetPickedup();
            }
        }
        if (other.gameObject.CompareTag("Gem") && slotLimit < 12)
        {
            var item = other.GetComponent<Grounditem>();
            GemsInventory.AddItem(new item(item._item), 1);
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
        if (response.gameObject.GetComponent<Enemy>() == target)
        {
            target = null;
        }
    }

    protected override void SetStats()
    {
        stats.attack = 10f;
        stats.defense = 1f;
        stats.evasion = 15f;
    }

    protected override void Attack()
    {
        if (target != null)
        {
            if (Random.Range(0, 100) > target.GetEvasion())
            {
                target.TakeDamage(GetAttack());
            }
        }
    }

    protected override void Die()
    {
        //restart level
        status = CharacterStatus.DEAD;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        GemsInventory.container.items.Clear();

    }
}
