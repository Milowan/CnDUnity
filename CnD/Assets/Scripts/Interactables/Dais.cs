using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dais : Interactable
{
    public Sprite spOn;
    public bool hasGem;
    public override void act()
    {
        if (hasGem == false)
        {
            if (!isOn)
            {
                GetComponent<SpriteRenderer>().sprite = spOn;
                hasGem = true;
            }
        }

    }
}
