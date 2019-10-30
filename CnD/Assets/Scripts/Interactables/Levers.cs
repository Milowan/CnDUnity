using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    public Sprite spOn, spOff;
    public Doors door;
    public override void act()
    {
        if (isOn)
        {
            door.m_doorCollider.enabled = true;
            //this.GetComponent<SpriteRenderer>().sprite = spOn;
        }
        else
        {
            door.m_doorCollider.enabled = false;
            //this.GetComponent<SpriteRenderer>().sprite = spOff;
        }

        isOn = !isOn;
    }

}
