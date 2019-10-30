using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    public Sprite spOn, spOff;
    public Sprite spOpen, spClosed;
    public Doors door;
    public override void act()
    {
        if (!isOn)
        {
            door.m_doorCollider.enabled = true;
            isOpen = false;
            GetComponent<SpriteRenderer>().sprite = spOn;
            door.GetComponent<SpriteRenderer>().sprite = spOpen;
        }
        else
        {
            door.m_doorCollider.enabled = false;
            isOpen = true;
            door.GetComponent<SpriteRenderer>().sprite = spClosed;
            GetComponent<SpriteRenderer>().sprite = spOff;
        }

        isOn = !isOn;
    }

}
