﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Sprite spOpen, spClosed;

    private Player player;

    protected bool isOn = false;
    protected bool isOpen = false;

    virtual public void act()
    {

    }
}
