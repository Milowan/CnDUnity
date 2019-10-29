using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Consumables")]

public class ConsumablesObject : ItemObject
{
    public int healValue;
    public void Awake()
    {
        type = ItemType.Consumable;
    }

}
