using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dais : Interactable
{
    public Sprite spOn;
    public override void act()
    {
        if (!isOn)
        {
            GetComponent<SpriteRenderer>().sprite = spOn;
            isOn = true;
        }
    }
}
