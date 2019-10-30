using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    Collider m_chestCollider;
    public Sprite spOpen, spClosed;
    public override void act()
    {
        if (isOpen)
        {
            m_chestCollider.enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = spOpen;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = spClosed;
        }
    }
}
