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
    private Interactable *interactable;

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
        //  interactable.act();
        }
    }
}
