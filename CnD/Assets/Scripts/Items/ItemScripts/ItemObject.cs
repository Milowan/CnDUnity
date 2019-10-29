using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Gear,
    Armour,
    Consumable,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay;
    //GameObject prefab;    // Changed from a prefab to a sprite
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}

[System.Serializable]
public class item
{
    public string name;
    public int ID;
    public item(ItemObject item)
    {
        name = item.name;
        ID = item.ID;
    }
}
