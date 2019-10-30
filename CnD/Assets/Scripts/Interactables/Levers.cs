using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    Doors m_collider;
    public override void act()
    {
        if (isOn)
        {
            m_collider.enabled = true;
        }
        else
        {
            m_collider.enabled = false;
        }
    }

}
