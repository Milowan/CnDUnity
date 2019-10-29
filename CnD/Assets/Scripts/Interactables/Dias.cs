using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dias : Interactable
{
    public bool gemOneSet = false;
    public bool gemTwoSet = false;
    public bool gemThreeSet = false;
    public bool gemFourSet = false;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DiasOne") && !gemOneSet)
        {

        }
        if (other.CompareTag("DiasTwo") && !gemTwoSet)
        {

        }
        if (other.CompareTag("DiasThree") && !gemThreeSet)
        {

        }
        if (other.CompareTag("DiasFour") && !gemFourSet)
        {

        }
    }
}
