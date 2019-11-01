using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    public Sprite spOn, spOff;
    public Doors door;
    public override void act()
    {
        if (getIsOn())
        {
            door.setIsOpen(false);
            GetComponent<SpriteRenderer>().sprite = spOn;
        }
        else
        {
            door.setIsOpen(true);
            GetComponent<SpriteRenderer>().sprite = spOff;
        }

        setIsOn(false);
    }

}
