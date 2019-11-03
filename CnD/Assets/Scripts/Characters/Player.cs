using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public static bool gamePaused = false;       // Pausing for inventory
    //private Sword *sword;
    //private Armour *armour;
    //private Helmet *helmet;
    public AudioSource playerAudio;
    public int mainAtkPoolSize;
    public int offAtkPoolSize;
    public GameObject mainAtk;
    public GameObject offAtk;
    protected List<Attack> mainAtkPool;
    protected List<Attack> offAtkPool;
    private Interactable interactable;

    // Inventory Vars //
    // Map Vars //
    public GameObject mapUI;
    public GameObject inventoryUI;




    // Start is called before the first frame update
    void Start()
    {
        movSpeed = 0.2f;
        stats = new Stats();
        SetStats();
        maxHealth = 50;
        health = maxHealth;
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        pos.tag = "Player";
        InitAtkPool(mainAtkPool, mainAtkPoolSize, mainAtk);
        InitAtkPool(offAtkPool, offAtkPoolSize, offAtk);
    }

    private void FixedUpdate()
    {
        pos.Translate(Input.GetAxis("Horizontal") * movSpeed, Input.GetAxis("Vertical") * movSpeed, 0f);
        SetDirection();

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
            Strike();
        }

        if (Input.GetButtonDown("Map"))
        {
            if (gamePaused)
            {
                UnpauseGame();
                mapUI.SetActive(false);
            }
            else
            {
                PauseGame();
                mapUI.SetActive(true);
            }
        }

        if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Cancel"))
        {
            if (gamePaused)
            {
                UnpauseGame();
                inventoryUI.SetActive(false);
                //hotbarUI.SetActive(false);

            }
            else
            {
                PauseGame();
                inventoryUI.SetActive(true);
                //inventoryUI.SetActive(true);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;

    }




    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with an Item, and if our slotLimit is less than 10, 1 item gets added to the inventory
       
        if (other.gameObject.CompareTag("FoW"))
        {
            Destroy(other.gameObject);
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

    protected override void Strike()
    {
        Attack currentAtk = null;
        for (int i = 0; i < mainAtkPoolSize; ++i)
        {
            if (!mainAtkPool[i].GetActive())
            {
                currentAtk = mainAtkPool[i];
                break;
            }
        }
        if (currentAtk != null)
        {
            currentAtk.Init(GetAttack(), facing, pos);
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

    }
}
