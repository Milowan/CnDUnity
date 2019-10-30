using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{ 
    private Player player;

    protected bool isOn = false;
    protected bool isOpen = false;

    public virtual void act()
    {

    }
    public bool getIsOn()
    {
        return isOn;
    }
}
