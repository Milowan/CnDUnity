using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    public override void act()
    {
        if (isOpen)
        {
            this.GetComponent<SpriteRenderer>().sprite = spOpen;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = spClosed;
        }
    }
}
