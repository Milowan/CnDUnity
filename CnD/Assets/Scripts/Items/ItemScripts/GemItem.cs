using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Gem")]
public class GemItem : ItemObject
{
    public bool isPickedUp;
    public void Awake()
    {
        type = ItemType.Gem;
    }


}
