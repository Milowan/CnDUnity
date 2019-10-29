using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Player player;
    public bool isOn = false;
    virtual public void OnTriggerEnter2D(Collider2D other)
    {

    }
}
