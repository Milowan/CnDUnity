using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public Inventory container;
    public ItemDatabaseObj database;
    // List to store all the items in the inventory
    // Add the item to the inventory, we search for the item in the list, if found we add it to the slot that had the item in it
    // if not, we creat a new inventory slot with that item in it.
    public void AddItem(item _item, int _amount)
    {
        if (_item.isStackable == false)
        {
            container.items.Add(new InventorySlot(_item.ID, _item, _amount));
            return;
        }
        for (int i = 0; i < container.items.Count; i++)
        {
            if (container.items[i].item.ID == _item.ID)
            {
                container.items[i].AddAmount(_amount);
                return;
            }
        }
        container.items.Add(new InventorySlot(_item.ID, _item, _amount));
    }
}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> items = new List<InventorySlot>();

}
[System.Serializable]
public class InventorySlot
{
    // ID is used to fine the item in the database
    public int ID;
    // An inventory slot that takes an item and an amount to store in the inventory list
    public item item;
    public int amount;
    public InventorySlot(int _id, item _item, int _amount)
    {
        // get the proper information for the item.
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}



