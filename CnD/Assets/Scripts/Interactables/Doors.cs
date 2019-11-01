using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    public Collider m_doorCollider;
    public bool isOpen = false;
    public Sprite spOpen, spClosed;
    public AudioClip clipOpen, clipClosed;
    public AudioSource doorSFX;
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
            GetComponent<AudioSource>().clip = clipClosed;
            doorSFX.Play();
        }
        else
        {
            m_doorCollider.enabled = false;
            GetComponent<SpriteRenderer>().sprite = spOpen;
            GetComponent<AudioSource>().clip = clipOpen;
            doorSFX.Play();
        }
        isOpen = !isOpen;
    }
}
