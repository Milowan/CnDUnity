using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    public Sprite spOpen, spClosed;
    public override void act()
    {
        if (!isOpen)
        {
            GetComponent<SpriteRenderer>().sprite = spOpen;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = spClosed;
        }
        isOpen = !isOpen;
    }
}
