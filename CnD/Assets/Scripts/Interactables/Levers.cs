using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    public Sprite spOn, spOff;
    Doors m_doorCollider;
    public override void act()
    {
        if (isOn)
        {
            m_doorCollider.enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = spOn;
        }
        else
        {
            m_doorCollider.enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = spOff;
        }
    }

}
