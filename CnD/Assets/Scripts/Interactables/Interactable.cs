using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Player player;
    public void OnTrigger(Collider other)
    {
        if(Input.GetButtonDown("Interact"))
        {
            act();
        }
    }

    virtual public void act()
    {

    }
}
