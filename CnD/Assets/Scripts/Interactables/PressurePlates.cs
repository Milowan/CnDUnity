using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    public bool hasRock;

    public Sprite spOn, spOff;
    public Doors door;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            door.m_doorCollider.enabled = false;
            door.setIsOpen(true);

            GetComponent<SpriteRenderer>().sprite = spOn;
        }

            //if(hasRock)
            //{
            //    door.m_doorCollider.enabled = false;
            //    door.setIsOpen(true);
            //    door.GetComponent<SpriteRenderer>().sprite = leverV.spClosed;
            //    GetComponent<SpriteRenderer>().sprite = spOff;
            //}
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.m_doorCollider.enabled = false;
            door.setIsOpen(false);
            GetComponent<SpriteRenderer>().sprite = spOff;
        }
    }
}
