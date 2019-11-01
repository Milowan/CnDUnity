using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Interactable
{
    public Sprite spOpen, spClosed;
    public GameObject[] chestItems;
    public bool isOpen = false;
    public AudioSource chestSFX;
    public override void act()
    {
        if(!isOpen)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            isOpen = true;
            if (getIsOpen() == true)
            {
                GetComponent<SpriteRenderer>().sprite = spOpen;
                Instantiate(chestItems[0], position, Quaternion.identity);
                chestSFX.Play();
            
            }
        }

    }

    public bool getIsOpen()
    {
        return isOpen;
    }
}
