using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    public Sprite spOpen, spClosed;
    public GameObject[] chestItems;
    public Transform spawnItemPos;
    public override void act()
    {
        if (!isOpen)
        {
            GetComponent<SpriteRenderer>().sprite = spOpen;
            Instantiate(chestItems[0], spawnItemPos.position, spawnItemPos.rotation);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = spClosed;
        }
        isOpen = !isOpen;
    }
}
