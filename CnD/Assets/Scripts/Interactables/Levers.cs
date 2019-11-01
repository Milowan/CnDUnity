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
            door.doorToggle();
            GetComponent<SpriteRenderer>().sprite = spOff;
        }
        else
        {
            door.doorToggle();
            GetComponent<SpriteRenderer>().sprite = spOn;

        }

        setIsOn(!getIsOn());
    }

}
