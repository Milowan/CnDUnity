using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if(other.CompareTag("Door") && !isOn)
        {

        }
        if (other.CompareTag("Door") && isOn)
        {

        }
    }
}
