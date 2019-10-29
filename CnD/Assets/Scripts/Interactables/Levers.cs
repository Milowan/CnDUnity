using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    public bool isOn = false;
    public override void act()
    {
        isOn = true;
        Debug.Log("isOn = " + isOn);
    }

}
