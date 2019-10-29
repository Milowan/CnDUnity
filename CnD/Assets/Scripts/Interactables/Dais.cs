using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dais : Interactable
{
    public bool gemOneSet = false;
    public bool gemTwoSet = false;
    public bool gemThreeSet = false;
    public bool gemFourSet = false;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DaisOne") && !gemOneSet)
        {

        }
        if (other.CompareTag("DaisTwo") && !gemTwoSet)
        {

        }
        if (other.CompareTag("DaisThree") && !gemThreeSet)
        {

        }
        if (other.CompareTag("DaisFour") && !gemFourSet)
        {

        }
    }
}
