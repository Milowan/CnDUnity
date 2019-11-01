using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Gem")]
public class GemItem : ItemObject
{
    public bool isPickedUp = false;
    public void Awake()
    {
        type = ItemType.Gem;
    }

    public bool GetPickedUp()
    {
        return isPickedUp;
    }

    public void SetPickedup()
    {
        isPickedUp = true;
    }
}
