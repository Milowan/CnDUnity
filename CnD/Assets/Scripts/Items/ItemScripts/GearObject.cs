using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Gear")]

public class GearObject : ItemObject
{
    public float EVBonus;
    public float Atkonus;
    public float DefValue;

    public void Awake()
    {
        type = ItemType.Gear;
    }
}


