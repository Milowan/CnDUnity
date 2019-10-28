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

    private void OnTriggerEnter(Collider response)
    {

    }
}
