using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Gear")]

public class GearObject : ItemObject
{
    public float range;
    public float Damage;
    public float speed;
    public float STRBonus;
    public float DexBonus;
    public float ConBonus;
    public float EVBonus;
    public float PrcBonus;

    public void Awake()
    {
        type = ItemType.Gear;
    }
}


