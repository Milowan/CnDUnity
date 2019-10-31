using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    public Sprite spOpen, spClosed;
    public GameObject[] chestItems;
    private Doors door;
    public override void act()
    {
        if (door.getIsOpen() == true)
        {
            GetComponent<SpriteRenderer>().sprite = spOpen;
            Instantiate(chestItems[0]);
        }
    }
}
