using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver  
{

    public ItemDatabaseObj database;
    // List to store all the items in the inventory
    public List<InventorySlot> container = new List<InventorySlot>();
    // Add the item to the inventory, we search for the item in the list, if found we add it to the slot that had the item in it
    // if not, we creat a new inventory slot with that item in it.
    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item)
            {
                container[i].AddAmount(_amount);
                return;
            }
        }
        container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
    }
    
    public void OnAfterDeserialize()
    {
        // For Get the item ID each item in the container
        for(int i = 0; i < container.Count; i++)
        {
            container[i].item = database.GetItem[container[i].ID];
        }
    }
    // We dont need to do anything before Seriaalization
    public void OnBeforeSerialize()
    {
    }
}


[System.Serializable]
public class InventorySlot
{
    // ID is used to fine the item in the database
    public int ID;
    // An inventory slot that takes an item and an amount to store in the inventory list
    public ItemObject item;
    public int amount;
    public InventorySlot(int _id, ItemObject _item, int _amount)
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



