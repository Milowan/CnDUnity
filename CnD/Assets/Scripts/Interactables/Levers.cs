using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : Interactable
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Lever") && !isOn)
        {

        }
        if(other.CompareTag("Lever") && isOn)
        {

        }
    }
}
