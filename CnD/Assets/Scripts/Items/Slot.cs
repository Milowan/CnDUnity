using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Player player;
    private Inventory inventory;
    public int i;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            Destroy(child.gameObject);
        }
    }
    //public void UseItem()
    //{
    //    if(gameObject.tag == "Potion1")
    //    {
    //        player.health = player.health + 20;
    //    }
    //    if(gameObject.tag == "Armour1")
    //    {

    //    }
    //    if(gameObject.tag == "Weapon1")
    //    {

    //    }
    //}
}
