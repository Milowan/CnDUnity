using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    public Collider m_doorCollider;

    private void Start()
    {
        m_doorCollider = GetComponent<Collider>();
    }
}
