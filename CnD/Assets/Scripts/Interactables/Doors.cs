using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    public Collider m_doorCollider;
    public bool isOpen = false;
    public Sprite spOpen, spClosed;
    private void Start()
    {
        m_doorCollider = GetComponent<Collider>();
    }

    public bool getIsOpen()
    {
        return isOpen;
    }
    public void doorToggle()
    {
        if (getIsOpen() == true)
        {
            m_doorCollider.enabled = true;
            GetComponent<SpriteRenderer>().sprite = spClosed;
        }
        else
        {
            m_doorCollider.enabled = false;
            GetComponent<SpriteRenderer>().sprite = spOpen;
        }
        isOpen = !isOpen;
    }
}
