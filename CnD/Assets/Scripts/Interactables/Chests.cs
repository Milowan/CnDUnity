using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    public Sprite spOpen, spClosed;
    public GameObject[] chestItems;
    public bool isOpen = false;
    private Doors door;
    public override void act()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        isOpen = true;
        if (getIsOpen() == true)
        {
            GetComponent<SpriteRenderer>().sprite = spOpen;
            Instantiate(chestItems[0], position, Quaternion.identity);
        }
    }

    public bool getIsOpen()
    {
        return isOpen;
    }
}
